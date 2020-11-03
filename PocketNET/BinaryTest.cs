using PocketNET.Core.Binary;
using PocketNET.Core.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace PocketNET
{
    public class BinaryTest
    {
        public BinaryTest()
        {
            Binary binary = new Binary();

            Console.WriteLine(Binary.ReadSignedByte(0xaf));
            Console.WriteLine(Binary.ReadSignedByte(4));
            Console.WriteLine(Binary.ReadSignedByte(5));

            // funciones que ya funcionan y dan los mismos resultad (https://github.com/PocketNET/BinaryData/blob/master/BinaryData.txt)

            // Binary.SignByte :D
            // Binary.UnsignByte :D
            // Binary.SignShort :D
            // Binary.UnsignShort :D
            // Binary.SignInt :D
            // Binary.ReadTriad :D
            // Binary.ReadLTriad :D
            // Binary.ReadBool :D
            // Binary.WriteBool :D
            // Binary.ReadSignedByte :D
            // Binary.WriteByte :D

            //On hold
            // Binary.WriteTriad 
            // Binary.WriteLTriad
        }
    }
}
