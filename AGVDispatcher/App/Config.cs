using ExtendedXmlSerializer;
using ExtendedXmlSerializer.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace AGVDispatcher.App
{

    [Serializable]
    //[XmlRoot("SaveData")]
    public class Config
    {
        [XmlElement]
        private Dictionary<int,AGVConfig> _AllAGV_ByOrder = new Dictionary<int, AGVConfig>();
        [XmlElement]
        private Dictionary<int, PLCConfig> _AllPLC_ByOrder = new Dictionary<int, PLCConfig>();
        [XmlElement]
        SystemConfig sysconfig;
        [XmlIgnore]
        public SystemConfig @SystemConfig { get => sysconfig; private set => sysconfig = value; }
        [XmlIgnore]
        public Dictionary<int, AGVConfig> AllAGV_ByOrder => _AllAGV_ByOrder;
        [XmlIgnore]
        public Dictionary<int, PLCConfig> AllPLC_ByOrder => _AllPLC_ByOrder;

        public Config()
        {
            sysconfig = new SystemConfig();
        }

        public int CheckDeviceByID(byte id,out IAGVDevConfig dev,bool checkagvuse = true)
        {
            foreach(var agv in _AllAGV_ByOrder)
            {
                if (id == agv.Value.AGVID && (!checkagvuse || agv.Value.InUse))
                {
                    dev = agv.Value;
                    return 1;
                }
            }
            foreach (var plc in _AllPLC_ByOrder)
            {
                if (id == plc.Value.PLCID)
                {
                    dev = plc.Value;
                    return -1;
                }
            }
            dev = null;
            return 0;
        }

        public void AddAGVConfig(AGVConfig agvc)
        {
            _AllAGV_ByOrder.Add(agvc.Order, agvc);
        }

        public void AddPLCConfig(PLCConfig plcc)
        {
            _AllPLC_ByOrder.Add(plcc.Order, plcc);
        }

        public void ClearAGVConfig() => _AllAGV_ByOrder.Clear();

        public void ClearPLCConfig() => _AllPLC_ByOrder.Clear();

        public int GetAGVByOrder(int order) => _AllAGV_ByOrder[order].AGVID;

        public int GetPLCByOrder(int order) => _AllPLC_ByOrder[order].PLCID;



        public void SaveToFile(string fname)
        {

            IExtendedXmlSerializer serializer = new ConfigurationContainer().Create();
            System.IO.FileStream file = System.IO.File.Create(fname);
            XmlWriterSettings setting = new XmlWriterSettings() { Indent = true };
            serializer.Serialize(setting, file, this);
            file.Close();
        }

        public void LoadFromFile(string fname)
        {
            IExtendedXmlSerializer serializer = new ConfigurationContainer().Create();
            var file = (System.IO.Stream)(new System.IO.FileStream(fname, System.IO.FileMode.Open));
            Config sd = serializer.Deserialize<Config>(file);
            file.Close();

            this.SystemConfig = sd.SystemConfig;
            this._AllAGV_ByOrder = sd._AllAGV_ByOrder;
            this._AllPLC_ByOrder = sd._AllPLC_ByOrder;
        }

        public static Config ReadFromFile(string fname)
        {
            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(Config));

            System.IO.StreamReader file = new System.IO.StreamReader(fname);

            Config sd = (Config)reader.Deserialize(file);
            file.Close();

            return sd;
        }
    }

    public static class GlobalConfig
    {
        private static Config conf;
        private static ReaderWriterLockSlim locker = new ReaderWriterLockSlim();

        
        public static class DebugConfig
        {
            public static int RunSkipFrom { get; set; } = 0;
        }

        public static void CreateNewConfig()
        {
            @Config = new Config();
        }

        public static Config @Config
        {
            get
            {
                locker.EnterReadLock();
                var rt = conf;
                locker.ExitReadLock();
                return rt;
            }
            private set
            {
                locker.EnterWriteLock();
                conf = value;
                locker.ExitWriteLock();
            }
        }
    }

    public interface IAGVDevConfig
    {
        public string Password { get; set; }
        public string IP { get; set; }
    }

    [Serializable]
    public class AGVConfig : IAGVDevConfig, IComparable<AGVConfig>
    {
        public byte AGVID { get; set; }
        public byte Order { get; set; }
        public string IP { get; set; }
        public string Password { get; set; }
        public bool InUse { get; set; } = true;

        public int CompareTo(AGVConfig other)
        {
            return this.Order - other.Order;
        }
    }

    [Serializable]
    public class PLCConfig : IAGVDevConfig, IComparable<AGVConfig>
    {
        public byte PLCID { get; set; }
        public string IP { get; set; }
        public string Password { get; set; }
        public byte Order { get; set; }
        public int CompareTo(AGVConfig other)
        {
            return this.Order - other.Order;
        }
    }

    [Serializable]
    public class SystemConfig
    {
        public ushort ListenPort { get; set; }
        public bool CheckIP { get; set; }
        public byte StopDelay { get; set; }
        public byte HookDelay { get; set; }
        public int AGVQueryInterval { get; set; }
        public int AGVComTimeout { get; set; }
    }
}
