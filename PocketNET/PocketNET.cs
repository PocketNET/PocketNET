using PocketNET.Core;
using PocketNET.Core.Utils;
using System;
using System.IO;

namespace PocketNET
{
    class PocketNET
    {
        static void Main(string[] args)
        {
            Console.WriteLine("__________              __           __   _______  ______________________");
            Console.WriteLine(@"\______   \____   ____ |  | __ _____/  |_ \      \ \_   _____/\__    ___/");
            Console.WriteLine(@" |     ___/  _ \_/ ___\|  |/ // __ \   __\/   |   \ |    __)_   |    |   ");
            Console.WriteLine(@" |    |  (  <_> )  \___|    <\  ___/|  | /    |    \|        \  |    |  ");
            Console.WriteLine(@" |____|   \____/ \___  >__|_ \\___  >__| \____|__  /_______  /  |____|  ");
            Console.WriteLine(@"                     \/     \/    \/             \/        \/            ");

            string dataPath = GetDataPath();

            if (!Directory.Exists(dataPath)) Directory.CreateDirectory(dataPath);

            SetupWizard wizard = new SetupWizard(dataPath);

            if (!wizard.Check()) wizard.Run();

            Logger.Info("Starting PocketNET services...");

            foreach (string path in new string[] { "plugins", "plugin_data", "worlds", "crashdumps", "texturepacks" })
            {
                try
                {
                    if (!Directory.Exists(dataPath + path)) Directory.CreateDirectory(dataPath + path);
                }
                catch (IOException e)
                {
                    Logger.Error(e.Message);
                }
            }

            do
            {
                // start Server.cd soon

                Logger.Info("PocketNET services stopped");
            }
            while (false);

            Environment.Exit(0);
        }

        public static string GetDataPath()
        {
            // In case of compiling from the idea remove the extra folders
            return Directory.GetCurrentDirectory().Replace(@"PocketNET\PocketNET\bin\Debug\netcoreapp3.1", "") + "server/";
        }
    }
}
