using System;
using System.Runtime.CompilerServices;
using Lizt.Generated.FindIndex;

namespace Lizt.Extensions
{
    public static class FindIndexExtensions
    {
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static int FindIndex(this Byte[] array, Byte value) => Gen.FindIndex(array, value, 0, array.Length);
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static int FindIndex(this Span<Byte> span, Byte value) => Gen.FindIndex(span, value, 0, span.Length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<Byte> span, Byte value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<Single> span, Single value) => Gen.FindIndex(span, value, 0, span.Length);
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static int FindIndex(this Span<Int32> span, Int32 value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<Double> span, Double value) => Gen.FindIndex(span, value, 0, span.Length);
    }
}
