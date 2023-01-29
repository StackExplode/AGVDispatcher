using AGVDispatcher.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.App
{
    public static class FakeTestInit
    {
        public static WareHouse House { get; set; }

        private static Config config;

        public static Config FakeReadConfig(string fname)
        {
            config = new Config();
            return config;
        }

        public static void InitSystem()
        {
            config.SystemConfig.AGVComTimeout = 10000;  //10s
            config.SystemConfig.AGVQueryInterval = 2000; //2s
            config.SystemConfig.CheckIP = false;
            config.SystemConfig.HookDelay = 15;
            config.SystemConfig.ListenPort = 17878;
            config.SystemConfig.StopDelay = 5;

        }
#warning 根据实际情况填写
        public static void InitAGVConfig()
        {
            
            
        }

        public static void InitPLCConfig()
        {

        }

        public static void InitMap()
        { 
            
        }

    }
}
