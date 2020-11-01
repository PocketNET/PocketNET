using System;
using System.IO;

namespace PocketNET.Core.Utils
{
    public class Logger
    {
        public static void Warning(string message)
        {
            Send("warning", ConsoleColor.Yellow, message);
        }

        public static void Error(string message)
        {
            Send("error", ConsoleColor.Red, message);

            DateTime date = DateTime.Now;

            string name = date.Day + "-" + date.Month + "-" + date.Year + "_" + date.Hour + "-" + date.Minute + "-" + date.Second;

            string body = @"Crashdump: [" + name + "]\n\n[Error]: " + message;

            string crashdumpRoute = PocketNET.GetDataPath() + "crashdumps/" + name + ".txt";

            try
            {
                File.WriteAllText(crashdumpRoute, body);
            } 
            catch (IOException e)
            {
                Error(e.Message);
            }

            Send("crashdump", ConsoleColor.Cyan, "New CrashDump created in " + crashdumpRoute);
        }

        public static void Info(string message)
        {
            Send("info", ConsoleColor.Gray, message);
        }

        private static void Send(string prefix, ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;

            Console.WriteLine("[{0}]: {1}", prefix.ToUpper(), message);

            Console.ResetColor();
        }
    }
}
