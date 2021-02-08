using Microsoft.Extensions.Logging;

namespace NLogWrapper
{
    public class NLogService
    {
        public static void BuildLogingConfiguration()
        {
            NLog.LogManager.LoadConfiguration("nlog.config");
        }

        public static void ConfigureLogging(ILoggingBuilder loggingBuilder)
        {
            NLogServiceNoConfigFile.ConfigureLogging(loggingBuilder);
        }
    }
}