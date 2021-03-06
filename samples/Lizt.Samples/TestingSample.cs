using System;
using Lizt.Extensions;

namespace Lizt.Samples
{
    static class TestingSample
    {
        public static void Main()
        {
            ReadOnlySpan<Byte> bytes = stackalloc byte[50];
            var foundIndexReadOnlySpan = bytes.FindIndex(0x00);
            Console.WriteLine(foundIndexReadOnlySpan);

            Span<Single> floatSpan = stackalloc Single[50];
            floatSpan[49] = 128F;
            var foundIndexSingle = floatSpan.FindIndex(128);
            Console.WriteLine(foundIndexSingle);

            Span<Double> doubleSpan = stackalloc Double[50];
            doubleSpan[3] = 128D;
            var foundIndexDouble = doubleSpan.FindIndex(128);
            Console.WriteLine(foundIndexDouble);

            Span<Int32> intSpan = stackalloc Int32[50];
            intSpan[3] = 128;
            var foundIndexInt = intSpan.FindIndex(128);
            Console.WriteLine(foundIndexInt);

            Span<Byte> byteSpan = stackalloc Byte[50];
            byteSpan[3] = 128;
            var foundIndexByte = byteSpan.FindIndex(128);
            Console.WriteLine(foundIndexByte);
        }
    }
}
