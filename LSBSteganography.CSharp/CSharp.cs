// topic: LSB Steganography
// The encoding algorithm sets the least significant bits of the image bytes to the bit value of the input text
// The decoding algorithm sets the bits of the output text to the value of the least significant bits of the image bytes
// author: Dominik Ciołczyk, semester: 5, date: 29.01.23
// ver 1.0

namespace LSBSteganography.CSharp
{
    public class CSharp
    {
        /** Method Encode
		 * Encodes bytes into image data bytes
		 * imageData image data table pointer
		 * imageIndex start index of image data table, 32-bit unsigned integer
		 * data start data table pointer
		 * startDataIndex start index of data table, 32-bit unsigned integer
		 * length number of characters, 32-bit unsigned integer
		 */
        public static void Encode(byte[] imageData, uint imageIndex, byte[] data, uint startDataIndex, uint length)
        {
            for (uint dataIndex = startDataIndex; dataIndex < startDataIndex + length; dataIndex++) {
                byte temp = data[dataIndex];
                for (uint i = 0; i < 8; i++) {
                    if ((temp & 1) == 0) imageData[imageIndex] &= 254;
                    else imageData[imageIndex] |= 1;
                    imageIndex++;
                    temp >>= 1;
                }
            }
		}

        /** Method Decode
         * Decodes text form image data
         * imageData image data table pointer
         * imageIndex start index of image data table, 32-bit unsigned integer
         * result start data result table pointer
         * startResultIndex start index of data result table, 32-bit unsigned integer
         * length number of characters, 32-bit unsigned integer
         */
        public static void Decode(byte[] imageData, uint indexImage, byte[] result, uint startResultIndex, uint length)
        {
            for (uint indexResult = startResultIndex; indexResult < startResultIndex + length; indexResult++)
            {
                byte temp = 0;
                for (uint i = 0; i < 8; i++) {
                    temp >>= 1;
                    if ((imageData[indexImage++] & 1) == 1) temp |= 128;
                }
                result[indexResult] = temp;
            }
        }
    }
}