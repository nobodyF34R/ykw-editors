using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Another_YW_4_Save_Editor
{
    internal class SetByteValue
    {
        private byte[] byte1 = new byte[1];
        private byte[] byte2 = new byte[2];
        private byte[] byte4 = new byte[4];

        public MemoryStream InjectByteFromInt(
          MemoryStream str,
          int value,
          int initialOffset,
          int count)
        {
            switch (count)
            {
                case 1:
                    this.byte1 = BitConverter.GetBytes(value);
                    str.Seek((long)initialOffset, SeekOrigin.Begin);
                    str.Write(this.byte1, 0, 1);
                    return str;
                case 2:
                    this.byte2 = BitConverter.GetBytes(value);
                    str.Seek((long)initialOffset, SeekOrigin.Begin);
                    str.Write(this.byte2, 0, 2);
                    return str;
                case 4:
                    this.byte4 = BitConverter.GetBytes(value);
                    str.Seek((long)initialOffset, SeekOrigin.Begin);
                    str.Write(this.byte4, 0, 4);
                    return str;
                default:
                    return str;
            }
        }

        public MemoryStream InjectByteFromFloat(MemoryStream str, float value, int initialOffset)
        {
            this.byte4 = BitConverter.GetBytes(value);
            str.Seek((long)initialOffset, SeekOrigin.Begin);
            str.Write(this.byte4, 0, 4);
            return str;
        }

        public MemoryStream InjectByteFromString(
          MemoryStream str,
          string value,
          int initialOffset,
          int count)
        {
            byte[] numArray1 = new byte[count];
            byte[] buffer;
            byte[] numArray2;
            for (buffer = Encoding.UTF8.GetBytes(value); buffer.Length < count; buffer = numArray2)
            {
                numArray2 = new byte[buffer.Length + (count - buffer.Length)];
                buffer.CopyTo((Array)numArray2, 0);
            }
            str.Seek((long)initialOffset, SeekOrigin.Begin);
            str.Write(buffer, 0, count);
            return str;
        }

        public MemoryStream InjectByteFromByteString(MemoryStream str, string value, int initialOffset)
        {
            byte[] array = ((IEnumerable<string>)value.Split('-')).Select<string, byte>((Func<string, byte>)(t => byte.Parse(t, NumberStyles.AllowHexSpecifier))).ToArray<byte>();
            str.Seek((long)initialOffset, SeekOrigin.Begin);
            str.Write(array, 0, ((IEnumerable<byte>)array).Count<byte>());
            return str;
        }

        public byte[] ExtractByteArray(Stream str, int initialOffset, int count)
        {
            switch (count)
            {
                case 1:
                    str.Seek((long)initialOffset, SeekOrigin.Begin);
                    str.Read(this.byte1, 0, 1);
                    return this.byte1;
                case 2:
                    str.Seek((long)initialOffset, SeekOrigin.Begin);
                    str.Read(this.byte2, 0, 2);
                    return this.byte2;
                case 4:
                    str.Seek((long)initialOffset, SeekOrigin.Begin);
                    str.Read(this.byte4, 0, 4);
                    return this.byte4;
                default:
                    return new byte[0];
            }
        }
    }
}
