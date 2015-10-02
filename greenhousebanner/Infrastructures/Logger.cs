using System;
using log4net;

namespace greenhousebanner.Infrastructures
{
    public class Logger
    {
        private const string LOGGER_NAME = "SSC_Core_Api_Logger";
        private static readonly ILog frameworkLogger;

        public static ILog FrameworkLogger
        {
            get { return frameworkLogger; }
        }

        static Logger()
        {
            log4net.Config.XmlConfigurator.Configure();
            frameworkLogger = LogManager.GetLogger(LOGGER_NAME);
        }

        public static void Error(object msg)
        {
            FrameworkLogger.Error(msg);
        }

        public static void Error(object msg, Exception e)
        {
            FrameworkLogger.Error(msg, e);
        }

        public static void Info(object msg)
        {
            FrameworkLogger.Info(msg);
        }

        public static void Info(object msg, Exception e)
        {
            FrameworkLogger.Info(msg, e);
        }
    }
}