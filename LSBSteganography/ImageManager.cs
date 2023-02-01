// topic: LSB Steganography
// The encoding algorithm sets the least significant bits of the image bytes to the bit value of the input text
// The decoding algorithm sets the bits of the output text to the value of the least significant bits of the image bytes
// author: Dominik Ciołczyk, semester: 5, date: 29.01.23
// ver 1.0

using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;

namespace LSBSteganography
{
    static class ImageManager
    {
        private static Bitmap bitmap; // bitmap of input image
        private static byte[] imageData; // data bytes of imput image
		private static uint size; // size of data in input image

		/** Method GetSize
		 * Getter of size field
		 * returns size field
		 */
		public static uint GetSize() { return size; }

        private static uint characters; // amount of characters that can be saved in image

		/** Method GetCharacters
		 * Getter of characters field
		 * returns characters field
		 */
		public static uint GetCharacters() { return characters; }

		/** Method Init
		 * Creates bitmap, sets size and characters fields and extracts data from an image to imageData field
		 * filename string path
		 * returns newly created bitmap
		 */
		public static Bitmap Init(string filename)
        {
			bitmap = new Bitmap(filename);
			
			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb); // BitmapData object used to get size and a copy of data
			size = (uint)(bitmapData.Stride * bitmapData.Height);
			characters = size / 8;

			imageData = new byte[size];
			Marshal.Copy(bitmapData.Scan0, imageData, 0, (int)size);
			bitmap.UnlockBits(bitmapData);

			return bitmap;
		}

		/** Method GetData
		 * Creates new array, copy of imageData field
		 * returns copy of imageData field
		 */
		public static byte[] GetData() { return imageData.ToArray(); }

		/** Method GenerateBitmap
		 * Creates new bitmap form byte array
		 * byteArray byte array of image to be created
		 * returns new bitmap
		 */
		public static Bitmap GenerateBitmap(byte[] byteArray)
        {
			Bitmap result = new Bitmap(bitmap);
			BitmapData resultData = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb); // BitmapData object used to get size and a copy of data

			Marshal.Copy(byteArray, 0, resultData.Scan0, (int)size);
			result.UnlockBits(resultData);
			return result;
		}
	}
}
