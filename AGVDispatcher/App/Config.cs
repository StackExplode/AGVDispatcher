using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AGVDispatcher.App
{
    [Serializable]
    [XmlRoot("SaveData")]
    public class Config
    {
        private Dictionary<int,AGVConfig> AllAGV_ByOrder { get; set; } = new Dictionary<int, AGVConfig>();
        private Dictionary<int, PLCConfig> AllPLC_ByOrder { get; set; } = new Dictionary<int, PLCConfig>();
        public SystemConfig @SystemConfig { get; set; }

        public Config()
        { 
            SystemConfig = new SystemConfig();
        }

        public int CheckDeviceByID(byte id,out IAGVDevConfig dev,bool checkagvuse = true)
        {
            foreach(var agv in AllAGV_ByOrder)
            {
                if (id == agv.Value.AGVID && (!checkagvuse || agv.Value.InUse))
                {
                    dev = agv.Value;
                    return 1;
                }
            }
            foreach (var plc in AllPLC_ByOrder)
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
            AllAGV_ByOrder.Add(agvc.Order, agvc);
        }

        public void AddPLCConfig(PLCConfig plcc)
        {
            AllPLC_ByOrder.Add(plcc.Order, plcc);
        }

        public void ClearAGVConfig() => AllAGV_ByOrder.Clear();

        public void ClearPLCConfig() => AllPLC_ByOrder.Clear();

        public int GetAGVByOrder(int order) => AllAGV_ByOrder[order].AGVID;

        public int GetPLCByOrder(int order) => AllPLC_ByOrder[order].PLCID;



        public void SaveToFile(string fname)
        {

            XmlSerializer writer = new XmlSerializer(this.GetType());
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

            System.IO.FileStream file = System.IO.File.Create(fname);

            writer.Serialize(file, this, ns);
            file.Close();
        }

        public static Config LoadFromFile(string fname)
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
        public static Config @Config
        {
            get
            {
                locker.EnterReadLock();
                var rt = conf;
                locker.ExitReadLock();
                return rt;
            }
            set
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
