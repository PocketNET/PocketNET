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
                Console.WriteLine("This program is free software: you can redistribute it and/or modify");
                Console.WriteLine("it under the terms of the GNU General Public License as published by");
                Console.WriteLine("the Free Software Foundation, either version 3 of the License, or");
                Console.WriteLine("(at your option) any later version.");
                Console.WriteLine("");
                Console.WriteLine("This program is distributed in the hope that it will be useful,");
                Console.WriteLine("but WITHOUT ANY WARRANTY; without even the implied warranty of");
                Console.WriteLine("MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the");
                Console.WriteLine("GNU General Public License for more details.");
                Console.WriteLine("");
                Console.WriteLine("You should have received a copy of the GNU General Public License");
                Console.WriteLine("along with this program.  If not, see <http://www.gnu.org/licenses/>.");

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
            config.Set("ip", "0.0.0.0");
            config.Set("port", port);
            config.Set("max-players", players);

            config.Save();

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Configuration finished! Starting server, one moment please...");

            Console.ResetColor();
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
