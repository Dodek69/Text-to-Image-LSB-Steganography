// topic: LSB Steganography
// The encoding algorithm sets the least significant bits of the image bytes to the bit value of the input text
// The decoding algorithm sets the bits of the output text to the value of the least significant bits of the image bytes
// author: Dominik Ciołczyk, semester: 5, date: 29.01.23
// ver 1.0

using System.Diagnostics;

namespace LSBSteganography
{
    static class Timer
    {
        private static readonly Stopwatch stopWatch = new Stopwatch(); // Stopwatch object used to measure time

        /** Method Start
         * Resets timer and starts it
         */
        public static void Start() {
            stopWatch.Reset();
            stopWatch.Start();
        }

        /** Method Stop
        * Stops timer and returns string of elapsed ticks
        * returns string containing number of ticks elapsed since Start method was called
        */
        public static string Stop() {
            stopWatch.Stop();
            return stopWatch.ElapsedTicks.ToString();
        }
    }
}