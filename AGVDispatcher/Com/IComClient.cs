using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using AGVDispatcher.App;

namespace AGVDispatcher.Com
{
    public delegate void OnDisconnectedDlg();
    public interface IComClient
    {
        bool IsAlive { get; set; }

        void Disconnect();
        void Disconnected();
        public event OnDisconnectedDlg OnDisconnected;
    }

    public interface IBlockedCom
    {
        public void Lock();
        public void UnLock();
    }

    public class AGVTCPClient : IComClient, IBlockedCom
    {
        SemaphoreSlim mutex = new SemaphoreSlim(1);
        public void Lock() => mutex.Wait(GlobalConfig.Config.SystemConfig.AGVComTimeout);
        public void UnLock() => mutex.Release();

        public AGVTCPClient(TcpClient cl)
        {
            Client = cl;
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
            Client.Close();
            IsAlive = false;
            OnDisconnected?.Invoke();
        }

        public void Disconnected()
        {
            IsAlive = false;
            OnDisconnected?.Invoke();
        }
        //public bool IsAlive => Client.Connected;


    }
}
