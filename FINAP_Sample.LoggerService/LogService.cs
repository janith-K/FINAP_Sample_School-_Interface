using NLog;
using System;
using System.IO;

namespace FINAP_Sample.LoggerService
{
    public class LogService
    {
        public LogService()
        {

        }

        private static Logger _logger;

        public enum LoggerLevel : int
        {
            Trace = 1,
            Debug,
            Info,
            Warn,
            Error,
            Fatal
        }

        private static NLog.Logger Logger
        {
            get
            {
                if (_logger == null)
                    _logger = LogManager.GetCurrentClassLogger();
                return _logger;
            }
        }

        public static DateTime GetSystemDateTime()
        {
            DateTime utcDate = DateTime.UtcNow;
            return utcDate.AddHours(5.5);
        }

        public static void WriteLogMessage(string message, LoggerLevel logLevel)
        {
            try
            {
                string header = GetSystemDateTime().ToString("dd-MM-yyyy hh:mm:ss:ms") + " | ";
                message = header + message + Environment.NewLine;

                File.AppendAllText($"Logs/{DateTime.Now.ToString("yyyyMMdd")}.txt", message);

                switch (logLevel)
                {
                    case LoggerLevel.Trace:
                        Logger.Trace(message);
                        break;
                    case LoggerLevel.Debug:
                        Logger.Debug(message);
                        break;
                    case LoggerLevel.Info:
                        Logger.Info(message);
                        break;
                    case LoggerLevel.Warn:
                        Logger.Warn(message);
                        break;
                    case LoggerLevel.Error:
                        Logger.Error(message);
                        break;
                    case LoggerLevel.Fatal:
                        Logger.Fatal(message);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }        
    }
}
