using System;
using PocketNET.Core.Config;

namespace PocketNET
{
    class PocketNET
    {
        static void Main(string[] args)
        {
            YamlConfig config = new YamlConfig(@"C:\Users\Jose Luis\Downloads\Servidor/config.yml");

            var list = new System.Collections.Generic.List<object>();
            list.Add("hi");
            list.Add("hi2");
            list.Add("hi3");

            config.SetList("Jose3", list);
            config.Save();


            var print = config.GetList("Jose3");

            Console.WriteLine(print.Get(0));
        }
    }
}
