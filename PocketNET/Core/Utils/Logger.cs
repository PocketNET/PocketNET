using System;

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
