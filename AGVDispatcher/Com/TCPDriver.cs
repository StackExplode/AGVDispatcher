﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;

namespace AGVDispatcher.Com
{
    public class TCPDriver : IComDriver
    {
        private bool disposedValue;

        private bool _running = false;
        //private bool _avaliable = false;

        private TcpListener _Listener;

        public bool IsRunning => _running;

        public bool IsAvaliable => _Listener == null ? false : true;

        List<IComClient> allclients = new List<IComClient>();

        public event OnComDataReceivedDlg OnComDataReceived;
        public event OnComClientConnectedDlg OnComClientConnected;
        public event OnComDataSentDlg OnComDataSent;
        public event OnComClientDisconnetedDlg OnComClientDisconneted;
        public event OnTransmitErrorDlg OnTransmitError;

        public IPAddress ListenIP { get; private set; }
        public ushort ListenPort { get; private set; }
        public int MaxClients { get; private set; }
        public int TransmitTimeout { get; set; } = 10000;
        public bool AsyncRecBuffer { get; set; } = true;

        public TCPDriver()
        {
            this.OnComClientDisconneted += (client) =>
            {
                allclients.Remove(client);
            };
            this.OnComClientConnected += (client) =>
            {
                allclients.Add(client);
            };
        }

        internal class RecState
        {
            public AGVTCPClient Client;
            public NetworkStream Stream { get { return Client.Client.GetStream(); } }
            public TcpClient TCPClient { get { return Client.Client; } }
            public byte[] Buffer;
        }

        public virtual void SetParameter(IPAddress ip,ushort port,int maxc = 1024)
        {
            if (_running)
            {
                throw new Exception("You can't set parameter when server is running!");
            }
            ListenIP = ip;
            ListenPort = port;
            MaxClients = maxc;
        }

        public void Init()
        {
            if (!_running)
                _Listener = new TcpListener(ListenIP, ListenPort);
            
        }
        private SemaphoreSlim send_mutex = new SemaphoreSlim(1);
        public virtual void SendData(IComClient client, byte[] data)
        {
            AGVTCPClient carclient = client as AGVTCPClient;
            NetworkStream ns = carclient.Client.GetStream();
            send_mutex.Wait();
            ns.WriteTimeout = TransmitTimeout;
            var task = ns.WriteAsync(data, 0, data.Length);
            task.ContinueWith((t) => {
                send_mutex.Release();
                this.OnComDataSent?.Invoke(client, data.Length); 
            });
        }

        public void Start()
        {
            if(!_running)
            {
                _running = true;
                _Listener.Start(MaxClients);
                _Listener.BeginAcceptTcpClient(new AsyncCallback(HandleAsyncConnection), _Listener);
            }
        }

        protected virtual void HandleAsyncConnection(IAsyncResult res)
        {
            if (_Listener == null || _Listener.Server == null || _Listener.Server.IsBound == false)
                return;
            TcpClient client = null;
            try
            {
                client = _Listener.EndAcceptTcpClient(res);
                if (_running)
                    _Listener.BeginAcceptTcpClient(HandleAsyncConnection, _Listener);
                
            }
            catch(ObjectDisposedException)
            {
                return;
            }
            catch (Exception ex)
            {
                OnTransmitError?.Invoke(null, ex);
            }
            if (client != null)
            {
                client.ReceiveTimeout = TransmitTimeout;
                byte[] buff = new byte[client.ReceiveBufferSize];
                client.GetStream().ReadTimeout = TransmitTimeout;
                AGVTCPClient carclient = new AGVTCPClient(client) { IsAlive = true };
                RecState state = new RecState { Client = carclient, Buffer = buff };
                carclient.OnDisconnected += (cl) => {
                    Debug.WriteLine("Client Disconnected!");
                    this.OnComClientDisconneted?.Invoke(cl); 
                };
                this.OnComClientConnected?.Invoke(carclient);
                state.Stream.BeginRead(state.Buffer, 0, state.Buffer.Length, HandleClientAsyncRec, state);
            }

        }

        int a = 0;
        protected virtual void HandleClientAsyncRec(IAsyncResult res)
        {
            
            RecState state = (RecState)res.AsyncState;
            TcpClient client = state.Client.Client;
            if (client == null)
                return;

            if (_Listener == null || _Listener.Server == null)
            {
                if (_Listener.Server.IsBound == false)
                    state.Client.Disconnect();
                return;
            }

            

            byte[] oldbuff = state.Buffer;
            
            if(client.Connected == false )
            {
                state.Client.Disconnect();
                return;
            }
            NetworkStream ns = state.Stream;

            int b2r = 0;
            try
            {
                b2r = ns.EndRead(res);
               
            }
            catch (System.IO.IOException)
            {
                b2r = 0;
            }
            catch(SocketException)
            {
                b2r = 0;
            }
            catch(ObjectDisposedException)
            {
                return;
            }
            catch (Exception ex)
            {
                OnTransmitError?.Invoke(state.Client, ex);
            }

            if (client.Available > 0)
            {
                //throw new Exception("Data too long!");
                a++;
            }
            if (b2r == 0)
            { 
                state.Client.Disconnect();
                return;
            } 
            else if(client.Available == 0 && !ns.DataAvailable)
            {
                //Debug.WriteLine($"TCP pack rec! Available={client.Available}, DataAvailable={ns.DataAvailable}");
                state.Client.IsAlive = true;
                if (AsyncRecBuffer)
                {
                    byte[] buffer = new byte[b2r];
                    Buffer.BlockCopy(state.Buffer, 0, buffer, 0, b2r);
                    Task.Run(() => this.OnComDataReceived?.Invoke(state.Client, buffer));
                }
                else
                    this.OnComDataReceived?.Invoke(state.Client, state.Buffer);
                if (_running && (client?.Connected ?? false))
                    state.Stream.BeginRead(state.Buffer, 0, state.Buffer.Length, HandleClientAsyncRec, state);
            }
            else
                Debug.WriteLineIf(false,$"TCP pack half! Available={client.Available}, DataAvailable={ns.DataAvailable}");
        }

        public void Stop(bool abort = false)
        {

            if(_running && (_Listener?.Server.IsBound ?? false))
            {
                _running = false;
                _Listener.Server.Close(1);
                _Listener.Stop();
                while(allclients.Count != 0)
                {
                    allclients.First().Disconnect();
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)
                }

                // TODO: 释放未托管的资源(未托管的对象)并替代终结器
                // TODO: 将大型字段设置为 null
                this.Stop(true);
                disposedValue = true;
            }
        }

        // TODO: 仅当“Dispose(bool disposing)”拥有用于释放未托管资源的代码时才替代终结器
        ~TCPDriver()
        {
            // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
