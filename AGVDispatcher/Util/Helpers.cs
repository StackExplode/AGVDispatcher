using AGVDispatcher.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.Util
{
    public static class Helpers
    {
        public static string ErrorLogGenerator(Exception ex)
        {
            StringBuilder sb = new StringBuilder();           
            sb.Append("[");
            sb.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ff"));
            sb.Append("]异常类型:");
            sb.Append(ex.GetType());
            sb.Append("\t异常信息：");
            sb.AppendLine(ex.Message);
            sb.AppendLine("详细信息：");
            sb.AppendLine(ex.ToString());
            sb.AppendLine();
            return sb.ToString();
        }

        public static void LogException(Exception ex)
        {
            Trace.TraceError(ErrorLogGenerator(ex));
            Trace.Flush();
        }

        public static void LogInfo(string msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            sb.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ff"));
            sb.Append("]");
            sb.Append(msg);
            sb.AppendLine();

            Trace.TraceInformation(sb.ToString());
            Trace.Flush();
        }

        [Conditional("SINGLE_DEBUG")]
        public static void SingleAGVDebug(string msg, params object[] pa)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            sb.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ff"));
            sb.Append("]");
            sb.Append(msg);
            Debug.WriteLine(sb.ToString(), pa);
        }

        [Conditional("SINGLE_DEBUG")]
        public static void SingleAGVDebugIf(bool con,string msg, params object[] pa)
        {
            if (con)
                SingleAGVDebug(msg, pa);
        }

        public static void WriteStringFile(string s, string fname)
        {
            FileStream fs = new FileStream(fname, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(s);
            sw.Close();
            fs.Close();
        }

        public static string DumpComData(IComData data)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("AGV=");
            sb.Append(data.AGVID);
            sb.Append(",DataType=");
            sb.Append(((ComDataType)data.RawBuffer[4]).GetDescription());
            sb.Append(",Check=");
            sb.Append(data.UnsafeAs<UnknownData>().CalcCheckSum().ToString("X2"));
            sb.Append(",Payload=");
            for (int i = 4; i < 24; i++)
                sb.Append(data.RawBuffer[i].ToString("X2") + " ");
            return sb.ToString();
        }

        
    }

}
