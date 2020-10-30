using System;
using PocketNET.Core.Binary;
using PocketNET.Core.Config;

namespace PocketNET
{
    class PocketNET
    {
        static void Main(string[] args)
        {
            YamlConfig config = new YamlConfig(@"C:\Users\Jose Luis\Downloads\Servidor/config.yml");

            Console.WriteLine(config.GetString("Jose"));
        }
    }
}
