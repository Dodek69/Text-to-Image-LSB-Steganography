using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSBSteganography
{
    
    static class Timer
    {
        static Stopwatch stopWatch = new Stopwatch();

        public static void Start() {
            stopWatch.Reset();
            stopWatch.Start();
        }
        public static string Stop() {
            stopWatch.Stop();

            return stopWatch.ElapsedMilliseconds + "ms";
        }
    }
}
