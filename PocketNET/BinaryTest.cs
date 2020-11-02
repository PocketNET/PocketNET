using PocketNET.Core.Binary;
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

            Console.WriteLine(Binary.WriteTriad(0xbf)[1]);

            // funciones que ya funcionan y dan los mismos resultad (https://github.com/PocketNET/BinaryData/blob/master/BinaryData.txt)

            // Binary.SignByte :D
            // Binary.UnsignByte :D
            // Binary.SignShort :D
            // Binary.UnsignShort :D
            // Binary.SignInt :D
            // Binary.ReadTriad :D

            //no work
            // Binary.WriteTriad :(
        }
    }
}
