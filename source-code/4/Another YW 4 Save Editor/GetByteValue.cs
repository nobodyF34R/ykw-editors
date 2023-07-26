using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Another_YW_4_Save_Editor
{
    internal class GetByteValue
    {
        private byte[] byte1 = new byte[1];
        private byte[] byte2 = new byte[2];
        private byte[] byte4 = new byte[4];
        private int[] intArray;
        private int[,] intArrayMatrix;

        public int ExtractByteToInt(Stream str, int initialOffset, int count)
        {
            switch (count)
            {
                case 1:
                    str.Seek((long)initialOffset, SeekOrigin.Begin);
                    str.Read(this.byte1, 0, 1);
                    return Convert.ToInt32(BitConverter.ToString(this.byte1, 0), 16);
                case 2:
                    str.Seek((long)initialOffset, SeekOrigin.Begin);
                    str.Read(this.byte2, 0, 2);
                    return (int)BitConverter.ToUInt16(this.byte2, 0);
                case 4:
                    str.Seek((long)initialOffset, SeekOrigin.Begin);
                    str.Read(this.byte4, 0, 4);
                    return BitConverter.ToInt32(this.byte4, 0);
                default:
                    return 0;
            }
        }

        public string ExtractByteToString(Stream str, int initialOffset, int count)
        {
            byte[] numArray = new byte[count];
            str.Seek((long)initialOffset, SeekOrigin.Begin);
            str.Read(numArray, 0, count);
            return Encoding.UTF8.GetString(numArray);
        }

        public float ExtractByteToFloat(Stream str, int initialOffset)
        {
            str.Seek((long)initialOffset, SeekOrigin.Begin);
            str.Read(this.byte4, 0, 4);
            return BitConverter.ToSingle(this.byte4, 0);
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

        public string ExtractByteArrayToString(Stream str, int initialOffset, int count)
        {
            switch (count)
            {
                case 1:
                    str.Seek((long)initialOffset, SeekOrigin.Begin);
                    str.Read(this.byte1, 0, 1);
                    return BitConverter.ToString(this.byte1);
                case 2:
                    str.Seek((long)initialOffset, SeekOrigin.Begin);
                    str.Read(this.byte2, 0, 2);
                    return BitConverter.ToString(this.byte2);
                case 4:
                    str.Seek((long)initialOffset, SeekOrigin.Begin);
                    str.Read(this.byte4, 0, 4);
                    return BitConverter.ToString(this.byte4);
                default:
                    return BitConverter.ToString(new byte[0]);
            }
        }

        public int[] ExtractBytetoIntArray(Stream str, int initialOffset, int count, int arrayLenght)
        {
            switch (count)
            {
                case 1:
                    this.intArray = new int[arrayLenght];
                    for (int index = 0; index < arrayLenght; ++index)
                    {
                        str.Seek((long)initialOffset, SeekOrigin.Begin);
                        str.Read(this.byte1, 0, 1);
                        this.intArray[index] = Convert.ToInt32(BitConverter.ToString(this.byte1, 0), 16);
                        ++initialOffset;
                    }
                    return this.intArray;
                case 2:
                    this.intArray = new int[arrayLenght];
                    for (int index = 0; index < arrayLenght; ++index)
                    {
                        str.Seek((long)initialOffset, SeekOrigin.Begin);
                        str.Read(this.byte2, 0, 2);
                        this.intArray[index] = (int)BitConverter.ToUInt16(this.byte2, 0);
                        initialOffset += 2;
                    }
                    return this.intArray;
                case 4:
                    this.intArray = new int[arrayLenght];
                    for (int index = 0; index < arrayLenght; ++index)
                    {
                        str.Seek((long)initialOffset, SeekOrigin.Begin);
                        str.Read(this.byte4, 0, 4);
                        this.intArray[index] = BitConverter.ToInt32(this.byte4, 0);
                        initialOffset += 4;
                    }
                    return this.intArray;
                default:
                    return this.intArray = new int[arrayLenght];
            }
        }
    }
}
