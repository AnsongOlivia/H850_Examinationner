using Serilog;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuneecFX01.system
{
    public static class sysLog
    {
        private static ILogger _logger;

        static sysLog()
        {
            _logger = new LoggerConfiguration()
                    .MinimumLevel.Verbose()
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .WriteTo.File("logs/Yuneec_.log",
                        outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}] [{Level:u4}] [{Source}] {Message:lj}{NewLine}{Exception}",
                        rollingInterval: RollingInterval.Day)
                    .CreateLogger();
        }

        public static void Trace(string strMsg)
        {
            using (LogContext.PushProperty("Source", getFileName() + ":" + getLineNo()))
            {
                _logger.Verbose(strMsg);
            }
        }
        public static void Trace<T>(string strMsg, T propertyValue)
        {
            using (LogContext.PushProperty("Source", getFileName() + ":" + getLineNo()))
            {
                _logger.Verbose(strMsg, propertyValue);
            }
        }

        public static void Debug(string strMsg)
        {
            using (LogContext.PushProperty("Source", getFileName() + ":" + getLineNo()))
            {
                _logger.Debug(strMsg);
            }
        }
        public static void Debug<T>(string strMsg, T propertyValue)
        {
            using (LogContext.PushProperty("Source", getFileName() + ":" + getLineNo()))
            {
                _logger.Debug(strMsg, propertyValue);
            }
        }
        public static void Debug<T0, T1>(string strMsg, T0 propertyValue0, T1 propertyValue1)
        {
            using (LogContext.PushProperty("Source", getFileName() + ":" + getLineNo()))
            {
                _logger.Debug(strMsg, propertyValue0, propertyValue1);
            }
        }
        public static void Debug<T0, T1, T2>(string strMsg, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
        {
            using (LogContext.PushProperty("Source", getFileName() + ":" + getLineNo()))
            {
                _logger.Debug(strMsg, propertyValue0, propertyValue1, propertyValue2);
            }
        }

        public static void Info(string strMsg)
        {
            using (LogContext.PushProperty("Source", getFileName() + ":" + getLineNo()))
            {
                _logger.Information(strMsg);
            }
        }

        internal static void Info<T>(string strMsg, T propertyValue)
        {
            using (LogContext.PushProperty("Source", getFileName() + ":" + getLineNo()))
            {
                _logger.Information(strMsg, propertyValue);
            }
        }

        public static void Warn(string strMsg)
        {
            using (LogContext.PushProperty("Source", getFileName() + ":" + getLineNo()))
            {
                _logger.Warning(strMsg);
            }
        }

        public static void Error(string strMsg)
        {
            using (LogContext.PushProperty("Source", getFileName() + ":" + getLineNo()))
            {
                _logger.Error(strMsg);
            }
        }

        public static void Error(Exception exception, string messageTemplate)
        {
            using (LogContext.PushProperty("Source", getFileName() + ":" + getLineNo()))
            {
                _logger.Error(exception, messageTemplate);
            }
        }

        public static void Fatal(string strMsg)
        {
            using (LogContext.PushProperty("Source", getFileName() + ":" + getLineNo()))
            {
                _logger.Fatal(strMsg);
            }
        }

        /// <summary>
        /// 当前行号
        /// </summary>
        public static int getLineNo()
        {
            StackTrace st = new StackTrace(1, true);

            return st.GetFrame(1).GetFileLineNumber();
        }

        /// <summary>
        /// 获得文件名
        /// </summary>
        public static string getFileName()
        {
            string strFileName = "";
            string[] strFullPath;

            StackTrace st = new StackTrace(1, true);
            var filename = st.GetFrame(1).GetFileName();
            if (filename == null) return "<filename unknown>";
            strFullPath = filename.Split(new char[] { '\\' });

            if (strFullPath != null)
            {
                strFileName = strFullPath[strFullPath.Length - 1];
            }

            return strFileName;
        }
        /// <summary>
        /// 向命令行输出二进制数据内容
        /// </summary>
        public static void printPacket(byte[] byBuffer, String strTag)
        {
            String strVal = "";
            for (int m = 0; m < byBuffer.Length; m++)
            {
                strVal = strVal + byBuffer[m].ToString("X2") + " ";
            }
            Console.WriteLine(DateTime.Now.ToString("hh:mm:ss.fff") + " -------------- " + strTag + "DATA[" + byBuffer.Length.ToString("D3") + "]" + strVal);
        }
    }
}
