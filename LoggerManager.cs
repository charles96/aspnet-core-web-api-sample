using NLog;

namespace aspnet_core_web_api_sample
{
        public interface ILoggerManager
        {
            void LogInfo(string message);
            void LogWarn(string message);
            void LogDebug(string message);
            void LogError(string message);
        }

    public class LoggerManager : ILoggerManager
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public void LogDebug(string message) => logger.Debug(message);
        public void LogError(string message) => logger.Error(message);
        public void LogInfo(string message) => logger.Info(message);
        public void LogWarn(string message) => logger.Warn(message);
    }
}
