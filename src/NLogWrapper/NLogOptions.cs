namespace NLogWrapper
{
    public class NLogOptions
    {
        public NLog.LogLevel FileLogLevel { get; set; } = NLog.LogLevel.Info;
        public NLog.LogLevel ConsoleLogLevel { get; set; } = NLog.LogLevel.Debug;
    }
}