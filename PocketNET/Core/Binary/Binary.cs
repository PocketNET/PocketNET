using System;
using System.Text;
using PocketNET.Core.Math;
using PocketNET.Core.Utils;

namespace PocketNET.Core.Binary
{
    public class Binary
    {
        public const short BIG_ENDIAN = 0x00;
        public const short LITTLE_ENDIAN = 0x01;

        public static int SignByte(int value)
        {
            return value << 56 >> 56;
        }

        public static int UnsignByte(int value)
        {
            return value & 0xff;
        }

        public static int SignShort(int value)
        {
            return value << 48 >> 48;
        }

        public static int UnsignShort(int value)
        {
            return value & 0xffff;
        }

        public static int SignInt(int value)
        {
            return value << 32 >> 32;
        }

        public static int UnsignInt(int value)
        {
            return (int)(value & 0xffffffff);
        }

        public static bool ReadBool(byte b)
        {
            return b == 0;
        }

        public static byte WriteBool(bool b)
        {
            return (byte)(b ? 0x01 : 0x00);
        }

        public static int ReadByte(string c)
        {
            string value = Convert.ToString(c[0]);

            return Functions.Ord(value);
        }

        public static int ReadSignedByte(byte b)
        {
            return b & 0xFF;
        }

        public static byte WriteByte(byte b)
        {
            return b;
        }

        public static int ReadShort(byte[] bytes)
        {
            return ((bytes[0] & 0xFF) << 8) + (bytes[1] & 0xFF);
        }

        public static short ReadSignedShort(byte[] bytes)
        {
            return (short)ReadShort(bytes);
        }

        public static byte[] WriteShort(int s)
        {
            return new byte[]{
                (byte) ((s >> 8) & 0xFF),
                (byte) (s & 0xFF)
            };
        }

        public static int ReadLShort(byte[] bytes)
        {
            return ((bytes[1] & 0xFF) << 8) + (bytes[0] & 0xFF);
        }

        public static short ReadSignedLShort(byte[] bytes)
        {
            return (short)ReadLShort(bytes);
        }

        public static byte[] WriteLShort(int s)
        {
            s &= 0xffff;

            return new byte[]{
                (byte) (s & 0xFF),
                (byte) ((s >> 8) & 0xFF)
            };
        }

        public static int ReadTriad(byte[] bytes)
        {
            return ReadInt(new byte[]{
                (byte) 0x00,
                bytes[0],
                bytes[1],
                bytes[2]
            });
        }

        public static object[] WriteTriad(int value)
        {
            sbyte first = (sbyte)(((uint)value >> 16) & 0xFF);
            sbyte second = (sbyte)(((uint)value >> 8) & 0xFF);
            sbyte thir = (sbyte)(value & 0xFF);

            return new object[] { first, second, thir };
        }

        public static int ReadLTriad(byte[] bytes)
        {
            return ReadLInt(new byte[]{
                bytes[0],
                bytes[1],
                bytes[2],
                (byte) 0x00
            });
        }

        public static object[] WriteLTriad(int value)
        {
            sbyte first = (sbyte)(value & 0xFF);
            sbyte second = (sbyte)(((uint)value >> 8) & 0xFF);
            sbyte thir = (sbyte)(((uint)value >> 16) & 0xFF);

            return new object[] { first, second, thir };
        }

        public static int ReadInt(byte[] bytes)
        {
            return ((bytes[0] & 0xff) << 24) +
                ((bytes[1] & 0xff) << 16) +
                ((bytes[2] & 0xff) << 8) +
                (bytes[3] & 0xff);
        }

        public static byte[] WriteInt(int i)
        {
            return new byte[]{
                (byte) ((i >> 24) & 0xFF),
                (byte) ((i >> 16) & 0xFF),
                (byte) ((i >> 8) & 0xFF),
                (byte) (i & 0xFF)
            };
        }

        public static int ReadLInt(byte[] bytes)
        {
            return ((bytes[3] & 0xff) << 24) +
                ((bytes[2] & 0xff) << 16) +
                ((bytes[1] & 0xff) << 8) +
                (bytes[0] & 0xff);
        }

        public static byte[] WriteLInt(int i)
        {
            return new byte[]{
                (byte) (i & 0xFF),
                (byte) ((i >> 8) & 0xFF),
                (byte) ((i >> 16) & 0xFF),
                (byte) ((i >> 24) & 0xFF)
            };
        }

        public static float ReadFloat(byte[] bytes)
        {
            return ReadFloat(bytes, -1);
        }

        public static float ReadFloat(byte[] bytes, int accuracy)
        {
            int x = ReadInt(bytes);
            byte[] bytesValue = BitConverter.GetBytes(x);
            float val = BitConverter.ToSingle(bytesValue, 0);

            if (accuracy > -1) return (float)PocketMath.Round(val, accuracy);

            return val;
        }

        public static byte[] WriteFloat(float f)
        {
            return WriteInt(BitConverter.ToInt32(BitConverter.GetBytes(f), 0));
        }

        public static float ReadLFloat(byte[] bytes)
        {
            return ReadLFloat(bytes, -1);
        }

        public static float ReadLFloat(byte[] bytes, int accuracy)
        {
            int x = ReadInt(bytes);
            byte[] bytesValue = BitConverter.GetBytes(x);
            float val = BitConverter.ToSingle(bytesValue, 0);

            if (accuracy > -1) return (float)PocketMath.Round(val, accuracy);

            return val;
        }

        public static byte[] WriteLFloat(float f)
        {
            return WriteLInt(BitConverter.ToInt32(BitConverter.GetBytes(f), 0));
        }

        public static double ReadDouble(byte[] bytes)
        {
            long value = ReadLong(bytes);

            return BitConverter.Int64BitsToDouble(value);
        }

        public static byte[] WriteDouble(double d)
        {
            return WriteLong(BitConverter.DoubleToInt64Bits(d));
        }

        public static double ReadLDouble(byte[] bytes)
        {
            long value = ReadLLong(bytes);

            return BitConverter.Int64BitsToDouble(value);
        }

        public static byte[] WriteLDouble(double d)
        {
            return WriteLLong(BitConverter.DoubleToInt64Bits(d));
        }

        public static long ReadLong(byte[] bytes)
        {
            return (((long)bytes[0] << 56) +
                ((long)(bytes[1] & 0xFF) << 48) +
                ((long)(bytes[2] & 0xFF) << 40) +
                ((long)(bytes[3] & 0xFF) << 32) +
                ((long)(bytes[4] & 0xFF) << 24) +
                ((bytes[5] & 0xFF) << 16) +
                ((bytes[6] & 0xFF) << 8) +
                ((bytes[7] & 0xFF)));
        }

        public static byte[] WriteLong(long l)
        {
            return new byte[]{
                (byte) (l >> 56),
                (byte) (l >> 48),
                (byte) (l >> 40),
                (byte) (l >> 32),
                (byte) (l >> 24),
                (byte) (l >> 16),
                (byte) (l >> 8),
                (byte) (l)
            };
        }

        public static long ReadLLong(byte[] bytes)
        {
            return (((long)bytes[7] << 56) +
                ((long)(bytes[6] & 0xFF) << 48) +
                ((long)(bytes[5] & 0xFF) << 40) +
                ((long)(bytes[4] & 0xFF) << 32) +
                ((long)(bytes[3] & 0xFF) << 24) +
                ((bytes[2] & 0xFF) << 16) +
                ((bytes[1] & 0xFF) << 8) +
                ((bytes[0] & 0xFF)));
        }

        public static byte[] WriteLLong(long l)
        {
            return new byte[]{
                (byte) (l),
                (byte) (l >> 8),
                (byte) (l >> 16),
                (byte) (l >> 24),
                (byte) (l >> 32),
                (byte) (l >> 40),
                (byte) (l >> 48),
                (byte) (l >> 56),
            };
        }

        public static int FlipShortEndianness(int value)
        {
            return ReadLShort(WriteShort(value));
        }

        public static int FlipIntEndianness(int value)
        {
            return ReadLInt(WriteInt(value));
        }

        public static int FlipLongEndianness(int value)
        {
            return (int)ReadLLong(WriteLong(value));
        }

        public static int ReadVarInt(byte[] bytes, int offset = 0)
        {
            int raw = ReadUnsignedVarInt(bytes, offset);
            int temp = (((raw >> 63) >> 63) ^ raw) >> 1;

            return temp ^ (raw & (1 >> 63));
        }

        public static int ReadUnsignedVarInt(byte[] bytes, int offset = 0)
        {
            if (bytes.Length <= 0) throw new ArgumentException("Expected more bytes, none left to read");

            if (offset > bytes.Length) throw new ArgumentException("Expected more bytes, none left to read");

            return bytes[offset];
        }

        public static byte[] WriteVarInt(int v)
        {
            int value = (v << 32 >> 32);

            return WriteUnsignedVarInt((value << 1) ^ (value >> 31));
        }

        public static byte[] WriteUnsignedVarInt(int value)
        {
            string buffer = "";
            value = (int)(value & 0xffffffff);
            
            for (int i = 0; i < 5; ++i)
            {
                if ((value >> 7) != 0)
                {
                    buffer += Convert.ToChar(value | 0x80);
                } else
                {
                    buffer += Convert.ToChar(value & 0x7f);

                    return Encoding.ASCII.GetBytes(buffer);
                }

                value = ((value >> 7) & (Int32.MaxValue >> 6));
            }

            throw new ArgumentException("Value too large to be encoded as a VarInt");
        }

        public static byte[] AppendBytes(byte[] bytes1, byte[] bytes2)
        {
            byte[] bytes = new byte[bytes1.Length + bytes2.Length];

            Array.Copy(bytes1, bytes, bytes1.Length);
            Array.Copy(bytes2, 0, bytes, bytes1.Length, bytes2.Length);

            return bytes;
        }

        public static byte[] SubBytes(byte[] bytes, int start, int length)
        {
            int len = (int)MathF.Min(bytes.Length, start + length);

            return Functions.CopyOfRange(bytes, start, len);
        }

        public static byte[] SubBytes(byte[] bytes, int start)
        {
            return SubBytes(bytes, start, bytes.Length - start);
        }
    }
}
