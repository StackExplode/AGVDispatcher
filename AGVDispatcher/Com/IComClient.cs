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
    public delegate void OnDisconnectedDlg(IComClient client);
    public interface IComClient
    {
        bool IsAlive { get; set; }

        void Disconnect();
        //void FireDisconnected();
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
