using PocketNET.Core;
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

            string dataPath = Directory.GetCurrentDirectory().Replace(@"PocketNET\PocketNET\bin\Debug\netcoreapp3.1", "") + "server/"; //// In case of compiling from the idea remove the extra folders

            if (!Directory.Exists(dataPath)) Directory.CreateDirectory(dataPath);

            SetupWizard wizard = new SetupWizard(dataPath);

            if (!wizard.Check()) wizard.Run();
        }
    }
}
