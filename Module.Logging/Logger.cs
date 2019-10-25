using System;

namespace Module.Logging
{
    public static class Logger
    {
        private static LoggingHandler logger = null;

        public static void Log(LoggingLevel level, string message)
        {
            logger = new LoggingHandler.FileLogging();
            logger.Log("[" + level + "/" + DateTime.Now + "]: " + message);

            Console.ForegroundColor = (ConsoleColor) level;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void Info(string message) => Log(LoggingLevel.INFO, message);

        public static void Debug(string message) => Log(LoggingLevel.DEBUG, message);

        public static void Warn(string message) => Log(LoggingLevel.WARN, message);

        public static void Error(string message) => Log(LoggingLevel.ERROR, message);
    }
}
