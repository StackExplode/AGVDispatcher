using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AGVDispatcher.App;
using AGVDispatcher.Com;

namespace AGVDispatcher.Entity
{
    public delegate void OnAGVStateUpdateDlg(IAGVDevice iagv);
    public delegate void OnAGVComStateUpdateDlg(IAGVDevice iagv, AGVComState before, AGVComState after);
    public interface IAGVDevice
    {
        public AGVTCPClient ComClient { get; }
        public AGVComState ComState { get; }
        public byte AGVID { get; }
        public IPAddress IP { get; }
        public IPAddress ExpectedIP { get; set; }
        public ushort LatestSerialCode { get; }
        public AGVServer Server { get; }
        public AGVType @AGVType { get; }

        public event OnAGVStateUpdateDlg OnAGVStateUpdate;
        public event OnAGVComStateUpdateDlg OnAGVComStateUpdate;

        public void Init(byte id, AGVTCPClient client, AGVServer server, IAGVDevConfig conf);

    }
}
