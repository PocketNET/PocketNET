using PocketNET.Core.Config;
using System;
using System.IO;

namespace PocketNET.Core
{
    public class SetupWizard
    {
        private const int DEFAULT_PORT = 19132;
        private const int DEFAULT_PLAYERS = 100;
        private const string DEFAULT_MOTD = "PocketNET Server";

        private string route { get; set; }

        private bool licence = false;
        private int port = -1;
        private int players = -1;
        private string motd = "null";

        public SetupWizard(string route)
        {
            this.route = route;
        }

        public bool Check()
        {
            if (!File.Exists(route + "server.yml"))
            {
                return false;
            }

            return true;
        }

        public void Run()
        {
            do
            {
                if (GetInput("Accept the license of use?", "n", "y/N") == "y") licence = true;
            }
            while (licence == false);

            do
            {
                port = Convert.ToInt32(GetInput("Insert the port on which the server will run", Convert.ToString(DEFAULT_PORT)));
            }
            while (port == -1);

            do
            {
                players = Convert.ToInt32(GetInput("Insert the maximum number of players", Convert.ToString(DEFAULT_PLAYERS)));
            }
            while (players == -1);

            do
            {
                motd = GetInput("Insert the server name", DEFAULT_MOTD);
            }
            while (motd == "null");

            YamlConfig config = new YamlConfig(route + "server.yml");

            config.Set("motd", motd);
            config.Set("port", port);
            config.Set("max-players", players);

            config.Save();
        }

        private string GetInput(string message, string defaultInput = "", string options = "")
        {
            message = "[?] " + message;

            if (options != "" || defaultInput != "")
            {
                message += " (" + (options == "" ? defaultInput : options) + ")";
            }

            message += ": ";

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(message);

            Console.ResetColor();

            string input = Console.ReadLine();

            return input == "" ? defaultInput : input;
        }
    }
}
