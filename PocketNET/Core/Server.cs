using PocketNET.Core.Config;
using PocketNET.Core.Utils;
using System;

namespace PocketNET.Core
{
    public class Server
    {
        private string path { get; set; }
        private string pluginPath { get; set; }

        private static Server instance { get; set; }

        private YamlConfig properties { get; set; }

        public Server(string path)
        {
            instance = this;

            this.path = path;
            pluginPath = path + "plugins/";

            try
            {
                properties = new YamlConfig(GetDataPath() + "server.yml");
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
            }

        }

        public static Server GetInstance()
        {
            return instance;
        }

        public string GetDataPath()
        {
            return path;
        }

        public string GetPluginPath()
        {
            return pluginPath;
        }

        public YamlConfig GetServerProperties()
        {
            return properties;
        }

        public string GetIp()
        {
            return properties.GetString("ip");
        }

        public int GetPort()
        {
            return properties.GetInt32("port");
        }

        public int GetMaxPlayers()
        {
            return properties.GetInt32("max-players");
        }

        public string GetMotd()
        {
            return properties.GetString("motd");
        }
    }
}
