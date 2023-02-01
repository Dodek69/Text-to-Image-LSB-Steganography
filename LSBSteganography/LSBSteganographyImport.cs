// topic: LSB Steganography
// The encoding algorithm sets the least significant bits of the image bytes to the bit value of the input text
// The decoding algorithm sets the bits of the output text to the value of the least significant bits of the image bytes
// author: Dominik Ciołczyk, semester: 5, date: 29.01.23
// ver 1.0

using System.Runtime.InteropServices;

namespace LSBSteganography
{
    static class LSBSteganographyImport
    {
        /** Method Encode
		 * Allows to call Encode procedure in LSBSteganography.Assembler DLL library
		 * imageData image data array
		 * imageIndex start index of image data array, 32-bit unsigned integer
		 * data start data array
		 * startDataIndex start index of data array, 32-bit unsigned integer
		 * length number of characters, 32-bit unsigned integer
		 */
        [DllImport(@"..\..\..\x64\Release\LSBSteganography.Assembler.dll")]
        //[DllImport(@"..\..\..\x64\Debug\LSBSteganography.Assembler.dll")]
        public static extern void Encode(byte[] imageData, uint imageIndex, byte[] data, uint startDataIndex, uint length);

        /** Method Decode
         * Allows to call Decode procedure in LSBSteganography.Assembler DLL library
         * imageData image data array
         * imageIndex start index of image data array, 32-bit unsigned integer
         * result start data result array
         * startResultIndex start index of data result array, 32-bit unsigned integer
         * length number of characters, 32-bit unsigned integer
         */
        [DllImport(@"..\..\..\x64\Release\LSBSteganography.Assembler.dll")]
        //[DllImport(@"..\..\..\x64\Debug\LSBSteganography.Assembler.dll")]
        public static extern void Decode(byte[] imageData, uint imageIndex, byte[] result, uint startResultIndex, uint length);
    }
}