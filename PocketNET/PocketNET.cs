using System;
using System.Collections.Generic;
using PocketNET.Core.Config;

namespace PocketNET
{
    class PocketNET
    {
        static void Main(string[] args)
        {
            JsonConfig config = new JsonConfig(@"C:\Users\Jose Luis\Downloads\Servidor/myjson.json");

            config.Set("test", 1);
            config.Set("test1", "jose");
            config.Set("test2", true);
            config.Save();

            Console.WriteLine(config.GetInt32("test"));
            Console.WriteLine(config.GetString("test1"));
            Console.WriteLine(config.GetBool("test2"));
        }
    }
}
