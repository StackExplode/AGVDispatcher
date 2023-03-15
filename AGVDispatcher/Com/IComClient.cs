using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using AGVDispatcher.App;
using System.Diagnostics;

namespace AGVDispatcher.Com
{
    public delegate void OnDisconnectedDlg(IComClient client);
    public delegate void OnClientTimeoutDlg(IComClient client);
    public interface IComClient
    {
        bool IsAlive { get; set; }

        void Disconnect();
        //void FireDisconnected();
        public event OnDisconnectedDlg OnDisconnected;
        public event OnClientTimeoutDlg OnClientTimeout;
    }

    public interface IBlockedCom
    {
        public void Lock();
        public void UnLock();
    }

    public class AGVTCPClient : IComClient, IBlockedCom
    {
        public event OnClientTimeoutDlg OnClientTimeout;
        SemaphoreSlim mutex = new SemaphoreSlim(1);
        SemaphoreSlim mutex2 = new SemaphoreSlim(1);
        public void Lock()
        {
            mutex2.Wait();
#warning Bad Patch
            var rt = mutex.Wait(GlobalConfig.Config.SystemConfig.AGVComTimeout - 200);
            mutex2.Release();
            if (!rt)
            {
                string ip = (this.Client.Client.RemoteEndPoint as IPEndPoint)?.Address.ToString();
                if (mutex.CurrentCount <= 0)
                    mutex.Release();
                this.OnClientTimeout?.Invoke(this);
                Util.Helpers.LogWarning($"AGV Communication Timeout! IP={ip}");
                
            }
                
        }
        public void UnLock()
        {
            if (mutex.CurrentCount <= 0)
                mutex.Release();
        }

        private byte[] DataBuffer { get; }
        private int reclen = 0;
        private static int dlen => Entity.AGVComData<Entity.IComDataField>.DataLen;
        public bool RecData(byte[] buff,Action<byte[]> onRecFinish = null)
        {
            Buffer.BlockCopy(buff, 0, this.DataBuffer, this.reclen, buff.Length);
            this.reclen += buff.Length;
            if (reclen == dlen)
            {
                onRecFinish?.Invoke(this.DataBuffer);
                reclen = 0;
                return true;
            }
            else if (reclen > dlen)
            {
                string errstr = $"Rec Data too long! reclen={reclen} > {dlen}";
                reclen = 0;
                throw new Exception(errstr);
            }
            else
                return false;
        }

        public AGVTCPClient(TcpClient cl)
        {
            Client = cl;
            DataBuffer = new byte[dlen];
        }
        public TcpClient Client { get; }
        public bool IsAlive { get; set; } = false;
        public event OnDisconnectedDlg OnDisconnected;
        public IPAddress IP 
        {
            get
            {
                return ((IPEndPoint)this.Client.Client.RemoteEndPoint).Address;
            }
        }

        public void Disconnect()
        {
            if(IsAlive)
            {
                Client.Close();
                IsAlive = false;
                OnDisconnected?.Invoke(this);
            }  
        }

//         public void FireDisconnected()
//         {
//             Client.Close();
//             IsAlive = false;
//             OnDisconnected?.Invoke(this);
//         }
        //public bool IsAlive => Client.Connected;


    }
}
