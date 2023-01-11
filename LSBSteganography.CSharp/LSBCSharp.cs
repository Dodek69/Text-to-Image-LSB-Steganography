using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using System.IO;

using System.Threading;



namespace LSBSteganography.CSharp
{
    public class LSBCSharp
    {
        public static void Encode(ref byte[] imageData, uint indexImage, ref byte[] data, uint startIndexData, uint dataSize)
        {
            //string debug = "";

            for (uint indexData = startIndexData; indexData < startIndexData + dataSize; indexData++)
            {
                byte temp = data[indexData];

                for (int i = 0; i < 8; i++)
                {
                    if ((temp & 128) == 0)
                    {
                        imageData[indexImage++] &= 254;
                        //debug += '0';
                    }
                    else
                    {
                        imageData[indexImage++] |= 1;
                        //debug += '1';
                    }
                    temp <<= 1;
                }
                //debug += ' ';
            }
		}

        public static void Decode(ref byte[] imageData, uint indexImage, ref byte[] result, uint startIndexResult, uint amount)
        {
            for (uint indexResult = startIndexResult; indexResult < startIndexResult + amount; indexResult++) {
                for (uint i = 0; i < 8; i++) {
                    result[indexResult] <<= 1;
                    if ((imageData[indexImage++] & 1) == 0) {
                        result[indexResult] &= 254;
                    }
                    else {
                        result[indexResult] |= 1;
                    }
                }   
            }
        }
    }
}
