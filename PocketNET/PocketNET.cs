using System;
using PocketNET.Core.Binary;

namespace PocketNET
{
    class PocketNET
    {
        static void Main(string[] args)
        {
            BinaryStream stream = new BinaryStream();

            stream.PutByte(0x2d);
            stream.PutBool(true);
            stream.PutFloat((float)8.1);

            Console.WriteLine("Buffer: " + BitConverter.ToString(stream.GetBuffer()));
            Console.WriteLine("Byte: " + stream.GetByte());
            Console.WriteLine("Bool: " + stream.GetBool());
            Console.WriteLine("FLoat: " + stream.GetFloat());
        }
    }
}
