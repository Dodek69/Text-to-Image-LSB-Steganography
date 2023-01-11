using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;

namespace LSBSteganography
{
    static class ImageManager
    {
		static Bitmap bitmap;
		static byte[] byteArrayOriginal;
		static int size;
		static int characters;
		public static int GetSize()
        {
			return size;
		}
		public static int GetCharacters()
        {
			return characters;
		}
		
		public static Bitmap Init(string filename)
        {
			bitmap = new Bitmap(filename);
			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
			size = bitmapData.Stride * bitmapData.Height;
			characters = size / 8;

			byteArrayOriginal = new byte[size];
			Marshal.Copy(bitmapData.Scan0, byteArrayOriginal, 0, size);
			bitmap.UnlockBits(bitmapData);

			return bitmap;
		}

		public static byte[] GetBytes()
        {
			return byteArrayOriginal.ToArray();
		}

		public static Bitmap BitmapFromByteArray(byte[] byteArray)
        {
			Bitmap result = new Bitmap(bitmap);
			BitmapData resultData = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);

			Marshal.Copy(byteArray, 0, resultData.Scan0, size);
			result.UnlockBits(resultData);
			return result;
		}
	}
}
