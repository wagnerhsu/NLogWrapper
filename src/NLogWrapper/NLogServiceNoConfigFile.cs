using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;

namespace NLogWrapper
{
    public class NLogServiceNoConfigFile
    {
        public static void BuildLogingConfiguration(NLogOptions options, string logFileName = null)
        {
            var config = new NLog.Config.LoggingConfiguration();

            var fileName = "${basedir}/Logs/${processname}.log";
            if (logFileName != null)
            {
                fileName = $"${{basedir}}/Logs/${logFileName}.log";
            }

            // Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile")
            {
                FileName = fileName,
                Layout = "${longdate:format=yyyy-MM-dd HH:mm:ss.ffffff}|${logger}|${level:uppercase=true}|${processid}|${threadid}|${message} ${exception:format=tostring}"
            };
            var logconsole = new NLog.Targets.ColoredConsoleTarget("logconsole")
            {
                Layout = "${longdate:format=yyyy-MM-dd HH:mm:ss.ffffff}|${logger}|${level:uppercase=true}|${processid}|${threadid}|${message} ${exception:format=tostring}"
            };

            // Rules for mapping loggers to targets
            config.AddRule(options.ConsoleLogLevel, NLog.LogLevel.Fatal, logconsole);
            config.AddRule(options.FileLogLevel, NLog.LogLevel.Fatal, logfile);

            // Apply config
            LogManager.Configuration = config;
        }

        public static void ConfigureLogging(ILoggingBuilder loggingBuilder)
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            loggingBuilder.AddNLog(new NLogProviderOptions
            { CaptureMessageTemplates = true, CaptureMessageProperties = true });
        }
    }
}