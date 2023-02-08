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

        public static void WriteStringFile(string s, string fname)
        {
            FileStream fs = new FileStream(fname, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(s);
            sw.Close();
            fs.Close();
        }
    }
}
