using System;

namespace PocketNET.Core.Utils
{
    public class Functions
    {
        public static int Ord(string value)
        {
            char convert = Convert.ToChar(value);
            int ascii = convert;

            return ascii;
        }

        public static byte[] CopyOfRange(byte[] src, int start, int end)
        {
            int len = end - start;
            byte[] dest = new byte[len];
            // note i is always from 0
            for (int i = 0; i < len; i++)
            {
                dest[i] = src[start + i]; // so 0..n = 0+x..n+x
            }

            return dest;
        }

        public static long TripleShift(long n, int s)
        {
            if (n >= 0)
                return n >> s;
            return (n >> s) + (2 << ~s);
        }
    }
}
