using System;
using System.IO;

namespace Engine.Services
{
    public static class LoggingService
    {
        private const string LOG_FILE_Directory = "Logs";

        static LoggingService()
        {
            string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LOG_FILE_Directory);

            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }
        }

        public static void Log(Exception exception, bool isInnerException = false)
        {
            using (StreamWriter sw = new StreamWriter(LogFileName(), true))
            {
                sw.WriteLine(isInnerException ? "INNER EXCEPTION" : $"EXCEPTION: {DateTime.Now}");
                sw.WriteLine(new string(isInnerException ? '-' : '=', 40));
                sw.WriteLine($"{exception.Message}");
                sw.WriteLine($"{exception.StackTrace}");

                sw.WriteLine();  // Blank line, to make the log file easier to read
            }

            if (exception.InnerException != null)
            {
                Log(exception.InnerException, true);
            }
        }

        private static string LogFileName()
        {
            //This will create a seperate log file for each day
            // Not that we should need it, but nice to have
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LOG_FILE_Directory,
                $"BEGINNERRPG_{DateTime.Now:yyyyMMdd}.log");
        }
    }
}
