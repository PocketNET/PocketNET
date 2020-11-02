using PocketNET.Core.Utils;
using System;

namespace PocketNET.Core.Binary
{
    public class BinaryStream
    {
        public int offset;
        public byte[] buffer;
        public int count;

        public BinaryStream()
        {
            buffer = new byte[32];
            offset = 0;
            count = 0;
        }

        public BinaryStream(byte[] buffer)
        {
            this.buffer = buffer;
            offset = 0;
            count = buffer.Length;
        }

        public BinaryStream(byte[] buffer, int offset)
        {
            this.buffer = buffer;
            this.offset = offset;
            count = buffer.Length;
        }

        public void Reset()
        {
            offset = 0;
            buffer = new byte[0];
            count = buffer.Length;
        }

        public void Rewind()
        {
            offset = 0;
        }

        public void SetOffset(int offset)
        {
            this.offset = offset;
        }

        public void SetBuffer(byte[] buffer)
        {
            this.buffer = buffer;
        }

        public void SetBuffer(byte[] buffer, int offset)
        {
            SetBuffer(buffer);
            SetOffset(offset);
        }

        public int GetOffset()
        {
            return offset;
        }

        public byte[] GetBuffer()
        {
            return buffer;
        }

        public int GetCount()
        {
            return count;
        }

        public byte[] Get(int length)
        {
            if (length < 0)
            {
                offset = count - 1;

                return new byte[0];
            }

            length = (int)MathF.Min(length, GetCount() - offset);
            offset += length;

            return Functions.CopyOfRange(buffer, offset - length, offset);
        }

        public void Put(byte[] bytes)
        {
            if (bytes == null)
            {
                return;
            }

            EnsureCapacity(count + bytes.Length);

            Array.Copy(bytes, 0, buffer, count, bytes.Length);

            count += bytes.Length;
        }

        public long GetLong()
        {
            return Binary.ReadLong(Get(8));
        }

        public void PutLong(long l)
        {
            Put(Binary.WriteLong(l));
        }

        public int GetInt()
        {
            return Binary.ReadInt(Get(4));
        }

        public void PutInt(int i)
        {
            Put(Binary.WriteInt(i));
        }

        public long GetLLong()
        {
            return Binary.ReadLLong(Get(8));
        }

        public void PutLLong(long l)
        {
            Put(Binary.WriteLLong(l));
        }

        public int getLInt()
        {
            return Binary.ReadLInt(Get(4));
        }

        public void PutLInt(int i)
        {
            Put(Binary.WriteLInt(i));
        }

        public int GetShort()
        {
            return Binary.ReadShort(Get(2));
        }

        public void PutShort(int s)
        {
            Put(Binary.WriteShort(s));
        }

        public int GetLShort()
        {
            return Binary.ReadLShort(Get(2));
        }

        public void PutLShort(int s)
        {
            Put(Binary.WriteLShort(s));
        }

        public float GetFloat()
        {
            return GetFloat(-1);
        }

        public float GetFloat(int accuracy)
        {
            return Binary.ReadFloat(Get(4), accuracy);
        }

        public void PutFloat(float v)
        {
            Put(Binary.WriteFloat(v));
        }

        public float GetLFloat()
        {
            return GetLFloat(-1);
        }

        public float GetLFloat(int accuracy)
        {
            return Binary.ReadLFloat(Get(4), accuracy);
        }

        public void PutLFloat(float v)
        {
            Put(Binary.WriteLFloat(v));
        }

        public int GetTriad()
        {
            return Binary.ReadTriad(Get(3));
        }

        public void PutTriad(int t)
        {
            //Put(Binary.WriteTriad(t));
        }

        public int GetLTriad()
        {
            return Binary.ReadLTriad(Get(3));
        }

        public void PutLTriad(int t)
        {
            Put(Binary.WriteLTriad(t));
        }

        public bool GetBool()
        {
            return GetByte() == 0x01;
        }

        public void PutBool(bool b)
        {
            PutByte((byte)(b ? 1 : 0));
        }

        public int GetByte()
        {
            return buffer[offset++] & 0xff;
        }

        public void PutByte(byte b)
        {
            Put(new byte[] { b });
        }

        public bool Feof()
        {
            return offset < 0 || offset >= buffer.Length;
        }


        private void EnsureCapacity(int minCapacity)
        {
            if (minCapacity - buffer.Length > 0)
            {
                Grow(minCapacity);
            }
        }

        private void Grow(int minCapacity)
        {
            int MAX_ARRAY_SIZE = int.MaxValue - 5;

            int oldCapacity = buffer.Length;
            int newCapacity = oldCapacity << 1;

            if (newCapacity - minCapacity < 0)
            {
                newCapacity = minCapacity;
            }

            if (newCapacity - MAX_ARRAY_SIZE > 0)
            {
                newCapacity = HugeCapacity(minCapacity);
            }

            Array.Copy(buffer, buffer, newCapacity);
        }

        private static int HugeCapacity(int minCapacity)
        {
            int MAX_ARRAY_SIZE = int.MaxValue - 5;

            if (minCapacity < 0) throw new OutOfMemoryException();

            return (minCapacity > MAX_ARRAY_SIZE) ? int.MaxValue : MAX_ARRAY_SIZE;
        }
    }
}
