using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LSBSteganography
{
    class LSBSteganographyImport
    {
        [DllImport(@"..\..\..\x64\WindowsFormsAssembler.AlgorithmAsm.dll")]
        public static extern void RemoveGreenScreen(byte[] background, byte[] greenScreenBytes, int width, int startLine, int untilLine);
    }
}
