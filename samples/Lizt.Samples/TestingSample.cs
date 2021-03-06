using System;
using Lizt.Extensions;

namespace Lizt.Samples
{
    static class TestingSample
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Span<Single> floatSpan = stackalloc Single[50];
            floatSpan[49] = 128F;
            var foundIndexSingle = floatSpan.FindIndex(128);
            Console.WriteLine(foundIndexSingle);

            //Span<Double> doubleSpan = stackalloc Double[50];
            //doubleSpan[3] = 128D;
            //var foundIndexDouble = doubleSpan.FindIndex(128);
            //Console.WriteLine(foundIndexDouble);

            //Span<Int32> intSpan = stackalloc Int32[50];
            //intSpan[3] = 128;
            //var foundIndex = intSpan.FindIndex(128);
            //Console.WriteLine(foundIndex);

            //Span<Byte> byteSpan = stackalloc Byte[50];
            //byteSpan[3] = 128;
            //var foundIndex = byteSpan.FindIndex(128);
            //Console.WriteLine(foundIndex);
        }
    }
}
