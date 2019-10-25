using System.IO;

namespace Module.Logging
{
    public abstract class LoggingHandler
    {
        protected readonly object lockObject = new object();

        public abstract void Log(string message);

        public class FileLogging : LoggingHandler
        {
            private string latestPath = "./latest.log";

            public override void Log(string message)
            {
                lock (lockObject)
                {
                    using (StreamWriter writer = File.AppendText(latestPath))
                    {
                        writer.WriteLine(message);
                        writer.Close();
                    }
                }
            }
        }

    }
}
