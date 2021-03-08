using System;
using System.Runtime.CompilerServices;
using Lizt.Generated.FindIndex;

namespace Lizt.Extensions
{
    public static class FindIndexExtensions
    {
        // TODO: Decide on doc-commenting. Look into having an xml docs file?

#region Byte

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Byte[] array, Byte value) => Gen.FindIndex(array, value, 0, array.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Byte[] array, Byte value, int startIndex) => Gen.FindIndex(array, value, startIndex, array.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Byte[] array, Byte value, int startIndex, int count) => Gen.FindIndex(array, value, startIndex, count);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<Byte> span, Byte value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<Byte> span, Byte value, int startIndex) => Gen.FindIndex(span, value, startIndex, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<Byte> span, Byte value, int startIndex, int count) => Gen.FindIndex(span, value, startIndex, count);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<Byte> span, Byte value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<Byte> span, Byte value, int startIndex) => Gen.FindIndex(span, value, startIndex, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<Byte> span, Byte value, int startIndex, int count) => Gen.FindIndex(span, value, startIndex, count);

        #endregion Byte

        #region SByte

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this SByte[] array, SByte value) => Gen.FindIndex(array, value, 0, array.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this SByte[] array, SByte value, int startIndex) => Gen.FindIndex(array, value, startIndex, array.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this SByte[] array, SByte value, int startIndex, int count) => Gen.FindIndex(array, value, startIndex, count);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<SByte> span, SByte value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<SByte> span, SByte value, int startIndex) => Gen.FindIndex(span, value, startIndex, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<SByte> span, SByte value, int startIndex, int count) => Gen.FindIndex(span, value, startIndex, count);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<SByte> span, SByte value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<SByte> span, SByte value, int startIndex) => Gen.FindIndex(span, value, startIndex, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<SByte> span, SByte value, int startIndex, int count) => Gen.FindIndex(span, value, startIndex, count);

        #endregion SByte

        #region Int16

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Int16[] array, Int16 value) => Gen.FindIndex(array, value, 0, array.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Int16[] array, Int16 value, int startIndex) => Gen.FindIndex(array, value, startIndex, array.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Int16[] array, Int16 value, int startIndex, int count) => Gen.FindIndex(array, value, startIndex, count);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<Int16> span, Int16 value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<Int16> span, Int16 value, int startIndex) => Gen.FindIndex(span, value, startIndex, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<Int16> span, Int16 value, int startIndex, int count) => Gen.FindIndex(span, value, startIndex, count);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<Int16> span, Int16 value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<Int16> span, Int16 value, int startIndex) => Gen.FindIndex(span, value, startIndex, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<Int16> span, Int16 value, int startIndex, int count) => Gen.FindIndex(span, value, startIndex, count);

        #endregion Int16

        #region UInt16

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this UInt16[] array, UInt16 value) => Gen.FindIndex(array, value, 0, array.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this UInt16[] array, UInt16 value, int startIndex) => Gen.FindIndex(array, value, startIndex, array.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this UInt16[] array, UInt16 value, int startIndex, int count) => Gen.FindIndex(array, value, startIndex, count);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<UInt16> span, UInt16 value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<UInt16> span, UInt16 value, int startIndex) => Gen.FindIndex(span, value, startIndex, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<UInt16> span, UInt16 value, int startIndex, int count) => Gen.FindIndex(span, value, startIndex, count);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<UInt16> span, UInt16 value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<UInt16> span, UInt16 value, int startIndex) => Gen.FindIndex(span, value, startIndex, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<UInt16> span, UInt16 value, int startIndex, int count) => Gen.FindIndex(span, value, startIndex, count);

        #endregion UInt16

        #region Int32

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Int32[] array, Int32 value) => Gen.FindIndex(array, value, 0, array.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Int32[] array, Int32 value, int startIndex) => Gen.FindIndex(array, value, startIndex, array.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Int32[] array, Int32 value, int startIndex, int count) => Gen.FindIndex(array, value, startIndex, count);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<Int32> span, Int32 value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<Int32> span, Int32 value, int startIndex) => Gen.FindIndex(span, value, startIndex, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<Int32> span, Int32 value, int startIndex, int count) => Gen.FindIndex(span, value, startIndex, count);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<Int32> span, Int32 value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<Int32> span, Int32 value, int startIndex) => Gen.FindIndex(span, value, startIndex, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<Int32> span, Int32 value, int startIndex, int count) => Gen.FindIndex(span, value, startIndex, count);

        #endregion Int32

        #region UInt32

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this UInt32[] array, UInt32 value) => Gen.FindIndex(array, value, 0, array.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this UInt32[] array, UInt32 value, int startIndex) => Gen.FindIndex(array, value, startIndex, array.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this UInt32[] array, UInt32 value, int startIndex, int count) => Gen.FindIndex(array, value, startIndex, count);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<UInt32> span, UInt32 value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<UInt32> span, UInt32 value, int startIndex) => Gen.FindIndex(span, value, startIndex, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<UInt32> span, UInt32 value, int startIndex, int count) => Gen.FindIndex(span, value, startIndex, count);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<UInt32> span, UInt32 value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<UInt32> span, UInt32 value, int startIndex) => Gen.FindIndex(span, value, startIndex, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<UInt32> span, UInt32 value, int startIndex, int count) => Gen.FindIndex(span, value, startIndex, count);

        #endregion UInt32

        #region Int64

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Int64[] array, Int64 value) => Gen.FindIndex(array, value, 0, array.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Int64[] array, Int64 value, int startIndex) => Gen.FindIndex(array, value, startIndex, array.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Int64[] array, Int64 value, int startIndex, int count) => Gen.FindIndex(array, value, startIndex, count);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<Int64> span, Int64 value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<Int64> span, Int64 value, int startIndex) => Gen.FindIndex(span, value, startIndex, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<Int64> span, Int64 value, int startIndex, int count) => Gen.FindIndex(span, value, startIndex, count);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<Int64> span, Int64 value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<Int64> span, Int64 value, int startIndex) => Gen.FindIndex(span, value, startIndex, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<Int64> span, Int64 value, int startIndex, int count) => Gen.FindIndex(span, value, startIndex, count);

        #endregion Int64

        #region UInt64

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this UInt64[] array, UInt64 value) => Gen.FindIndex(array, value, 0, array.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this UInt64[] array, UInt64 value, int startIndex) => Gen.FindIndex(array, value, startIndex, array.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this UInt64[] array, UInt64 value, int startIndex, int count) => Gen.FindIndex(array, value, startIndex, count);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<UInt64> span, UInt64 value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<UInt64> span, UInt64 value, int startIndex) => Gen.FindIndex(span, value, startIndex, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<UInt64> span, UInt64 value, int startIndex, int count) => Gen.FindIndex(span, value, startIndex, count);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<UInt64> span, UInt64 value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<UInt64> span, UInt64 value, int startIndex) => Gen.FindIndex(span, value, startIndex, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<UInt64> span, UInt64 value, int startIndex, int count) => Gen.FindIndex(span, value, startIndex, count);

        #endregion UInt64

        #region Single

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Single[] array, Single value) => Gen.FindIndex(array, value, 0, array.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Single[] array, Single value, int startIndex) => Gen.FindIndex(array, value, startIndex, array.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Single[] array, Single value, int startIndex, int count) => Gen.FindIndex(array, value, startIndex, count);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<Single> span, Single value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<Single> span, Single value, int startIndex) => Gen.FindIndex(span, value, startIndex, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<Single> span, Single value, int startIndex, int count) => Gen.FindIndex(span, value, startIndex, count);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<Single> span, Single value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<Single> span, Single value, int startIndex) => Gen.FindIndex(span, value, startIndex, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<Single> span, Single value, int startIndex, int count) => Gen.FindIndex(span, value, startIndex, count);

        #endregion Single

        #region Double

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Double[] array, Double value) => Gen.FindIndex(array, value, 0, array.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Double[] array, Double value, int startIndex) => Gen.FindIndex(array, value, startIndex, array.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Double[] array, Double value, int startIndex, int count) => Gen.FindIndex(array, value, startIndex, count);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<Double> span, Double value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<Double> span, Double value, int startIndex) => Gen.FindIndex(span, value, startIndex, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this Span<Double> span, Double value, int startIndex, int count) => Gen.FindIndex(span, value, startIndex, count);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<Double> span, Double value) => Gen.FindIndex(span, value, 0, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<Double> span, Double value, int startIndex) => Gen.FindIndex(span, value, startIndex, span.Length);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FindIndex(this ReadOnlySpan<Double> span, Double value, int startIndex, int count) => Gen.FindIndex(span, value, startIndex, count);

        #endregion Double
    }
}
