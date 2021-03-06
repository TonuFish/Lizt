using System;
using System.Runtime.CompilerServices;
using Lizt.Generated.FindIndex;

namespace Lizt.Extensions
{
    public static class FindIndexExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Byte[] array, Byte value) => Gen.FindIndex(array, value, 0, array.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<Byte> span, Byte value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<Byte> span, Byte value) => Gen.FindIndex(span, value, 0, span.Length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this SByte[] array, SByte value) => Gen.FindIndex(array, value, 0, array.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<SByte> span, SByte value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<SByte> span, SByte value) => Gen.FindIndex(span, value, 0, span.Length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Int16[] array, Int16 value) => Gen.FindIndex(array, value, 0, array.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<Int16> span, Int16 value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<Int16> span, Int16 value) => Gen.FindIndex(span, value, 0, span.Length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this UInt16[] array, UInt16 value) => Gen.FindIndex(array, value, 0, array.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<UInt16> span, UInt16 value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<UInt16> span, UInt16 value) => Gen.FindIndex(span, value, 0, span.Length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Int32[] array, Int32 value) => Gen.FindIndex(array, value, 0, array.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<Int32> span, Int32 value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<Int32> span, Int32 value) => Gen.FindIndex(span, value, 0, span.Length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this UInt32[] array, UInt32 value) => Gen.FindIndex(array, value, 0, array.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<UInt32> span, UInt32 value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<UInt32> span, UInt32 value) => Gen.FindIndex(span, value, 0, span.Length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Int64[] array, Int64 value) => Gen.FindIndex(array, value, 0, array.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<Int64> span, Int64 value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<Int64> span, Int64 value) => Gen.FindIndex(span, value, 0, span.Length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this UInt64[] array, UInt64 value) => Gen.FindIndex(array, value, 0, array.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<UInt64> span, UInt64 value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<UInt64> span, UInt64 value) => Gen.FindIndex(span, value, 0, span.Length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Single[] array, Single value) => Gen.FindIndex(array, value, 0, array.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<Single> span, Single value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<Single> span, Single value) => Gen.FindIndex(span, value, 0, span.Length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Double[] array, Double value) => Gen.FindIndex(array, value, 0, array.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<Double> span, Double value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<Double> span, Double value) => Gen.FindIndex(span, value, 0, span.Length);
    }
}
