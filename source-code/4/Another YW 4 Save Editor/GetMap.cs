using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Another_YW_4_Save_Editor
{
    internal class GetMap
    {
        public int pickMapIndex(string bytes)
        {
            switch (bytes)
            {
                case "00-84-B0-03":
                    return 38;
                case "03-00-21-F7":
                    return 3;
                case "06-7C-CE-96":
                    return 21;
                case "11-A8-33-AB":
                    return 32;
                case "16-AE-95-01":
                    return 34;
                case "1E-3A-AA-0A":
                    return 42;
                case "2A-1D-C0-78":
                    return 18;
                case "2F-61-2F-19":
                    return 15;
                case "33-09-22-06":
                    return 28;
                case "36-A5-42-1E":
                    return 4;
                case "37-2B-35-9D":
                    return 36;
                case "3B-9D-1D-0D":
                    return 7;
                case "41-B5-AB-1A":
                    return 12;
                case "47-4D-D5-8F":
                    return 14;
                case "51-75-12-3F":
                    return 16;
                case "59-FF-B1-9E":
                    return 35;
                case "5A-BE-67-F5":
                    return 10;
                case "5F-14-60-81":
                    return 13;
                case "6B-2C-DB-61":
                    return 26;
                case "76-F3-2E-5E":
                    return 24;
                case "76-FD-55-7B":
                    return 30;
                case "89-58-2B-9F":
                    return 29;
                case "8B-B4-7D-30":
                    return 17;
                case "8D-2A-79-1A":
                    return 22;
                case "8F-6E-C0-C6":
                    return 44;
                case "92-F8-69-56":
                    return 40;
                case "95-30-26-80":
                    return 23;
                case "9B-68-5D-82":
                    return 20;
                case "9F-44-31-3C":
                    return 43;
                case "A0-95-45-69":
                    return 9;
                case "A5-E9-AA-08":
                    return 25;
                case "AE-13-CA-37":
                    return 1;
                case "B4-7B-6F-60":
                    return 41;
                case "B9-51-28-6E":
                    return 8;
                case "BF-DA-A7-2D":
                    return 6;
                case "CC-8E-60-82":
                    return 31;
                case "D1-1C-D3-D8":
                    return 39;
                case "D2-A2-F2-FD":
                    return 5;
                case "D7-85-AC-6D":
                    return 11;
                case "DE-9C-2A-FF":
                    return 19;
                case "E0-EF-6E-6C":
                    return 33;
                case "E8-4D-C5-A2":
                    return 27;
                case "EB-83-3C-9A":
                    return 37;
                case "EB-E7-BD-4A":
                    return 2;
                default:
                    return 0;
            }
        }
    }
}
