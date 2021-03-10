using System;
using FluentAssertions;
using Lizt.Extensions;
using Xunit;

namespace Lizt.Tests
{
    public class FindIndexTests
    {
        [MemberData(nameof(TestData), 0, 0, 0, null)]
        [Theory(DisplayName = "Parameters: Throws when source is empty")]
        public void Parameters_ThrowsWhenSourceIsEmpty(Func<int> methodCall)
        {
            methodCall.Should().Throw<Exception>();
        }

        [MemberData(nameof(TestData), 1, -1, 0, null)]
        [MemberData(nameof(TestData), 1, 1, 0, null)]
        [Theory(DisplayName = "Parameters: Throws when start index is out of range")]
        public void Parameters_ThrowsWhenStartIndexOutOfRange(Func<int> methodCall)
        {
            methodCall.Should().Throw<ArgumentOutOfRangeException>().And.ParamName.Should().Be("startIndex");
        }

        [MemberData(nameof(TestData), 1, 0, 0, null)]
        [MemberData(nameof(TestData), 1, 0, 2, null)]
        [Theory(DisplayName = "Parameters: Throws when count is out of range")]
        public void Parameters_ThrowsWhenCountOutOfRange(Func<int> methodCall)
        {
            methodCall.Should().Throw<ArgumentOutOfRangeException>().And.ParamName.Should().Be("count");
        }

        // TODO: Get valueIndex into test body to assert with
        //[MemberData(nameof(TestData), 100, 0, 100, 31)]
        //[MemberData(nameof(TestData), 100, 0, 100, 32)]
        //[MemberData(nameof(TestData), 100, 0, 100, 33)]
        //[Theory(DisplayName = "Result: Finds value on width boundary")]
        //public void Result_FindsValueOnWidthBoundary(Func<int> methodCall)
        //{
        //    // Arrange
        //    int? result = null;
        //    Action act = () => result = methodCall.Invoke();

        //    // Assert
        //    act.Should().NotThrow();
        //    result.Should().Be(48);
        //}

        [MemberData(nameof(TestData), 100, 0, 100, 33)]
        [Theory(DisplayName = "Result: Finds value in odd position")]
        public void Result_FindsValueInOddPosition(Func<int> methodCall)
        {
            // TODO: Remove temp test
            // Arrange
            int? result = null;
            Action act = () => result = methodCall.Invoke();

            // Assert
            act.Should().NotThrow();
            result.Should().Be(33);

            // Need fakes for this, might have to swap to VS2019-preview :\
            //System.Runtime.Intrinsics.X86.Avx.IsSupported.Should().
        }

        [MemberData(nameof(TestData), 100, 0, 100, null)]
        [Theory(DisplayName = "Result: Returns not found when value missing")]
        public void Result_ReturnsNotFoundWhenValueMissing(Func<int> methodCall)
        {
            // Arrange
            const int NotFound = -1;
            int? result = null;
            Action act = () => result = methodCall.Invoke();

            // Assert
            act.Should().NotThrow();
            result.Should().Be(NotFound);
        }

        public static TheoryData<Func<int>> TestData(int length, int startIndex, int count, int? valueIndex)
        {
            // TODO: This should really be cleaned up... maybe use MakeGenericMethod reflection, unsafe* returns?
            // Entire method is clunky, but readable? "Works" for now.
            // Using the same array for all 3 methods of each T is also bad.

            var bytes = CreateDataSource<Byte>(Byte.MaxValue);
            var sbytes = CreateDataSource<SByte>(SByte.MaxValue);
            var int16s = CreateDataSource<Int16>(Int16.MaxValue);
            var uint16s = CreateDataSource<UInt16>(UInt16.MaxValue);
            var int32s = CreateDataSource<Int32>(Int32.MaxValue);
            var uint32s = CreateDataSource<UInt32>(UInt32.MaxValue);
            var int64s = CreateDataSource<Int64>(Int64.MaxValue);
            var uint64s = CreateDataSource<UInt64>(UInt64.MaxValue);
            var singles = CreateDataSource<Single>(Single.MaxValue);
            var doubles = CreateDataSource<Double>(Double.MaxValue);

            return new TheoryData<Func<int>>
            {
                () => bytes.Array_.FindIndex(Byte.MaxValue, startIndex, count),
                () => bytes.S.Span.FindIndex(Byte.MaxValue, startIndex, count),
                () => bytes.R.Span.FindIndex(Byte.MaxValue, startIndex, count),
                () => sbytes.Array_.FindIndex(SByte.MaxValue, startIndex, count),
                () => sbytes.S.Span.FindIndex(SByte.MaxValue, startIndex, count),
                () => sbytes.R.Span.FindIndex(SByte.MaxValue, startIndex, count),
                () => int16s.Array_.FindIndex(Int16.MaxValue, startIndex, count),
                () => int16s.S.Span.FindIndex(Int16.MaxValue, startIndex, count),
                () => int16s.R.Span.FindIndex(Int16.MaxValue, startIndex, count),
                () => uint16s.Array_.FindIndex(UInt16.MaxValue, startIndex, count),
                () => uint16s.S.Span.FindIndex(UInt16.MaxValue, startIndex, count),
                () => uint16s.R.Span.FindIndex(UInt16.MaxValue, startIndex, count),
                () => int32s.Array_.FindIndex(Int32.MaxValue, startIndex, count),
                () => int32s.S.Span.FindIndex(Int32.MaxValue, startIndex, count),
                () => int32s.R.Span.FindIndex(Int32.MaxValue, startIndex, count),
                () => uint32s.Array_.FindIndex(UInt32.MaxValue, startIndex, count),
                () => uint32s.S.Span.FindIndex(UInt32.MaxValue, startIndex, count),
                () => uint32s.R.Span.FindIndex(UInt32.MaxValue, startIndex, count),
                () => int64s.Array_.FindIndex(Int64.MaxValue, startIndex, count),
                () => int64s.S.Span.FindIndex(Int64.MaxValue, startIndex, count),
                () => int64s.R.Span.FindIndex(Int64.MaxValue, startIndex, count),
                () => uint64s.Array_.FindIndex(UInt64.MaxValue, startIndex, count),
                () => uint64s.S.Span.FindIndex(UInt64.MaxValue, startIndex, count),
                () => uint64s.R.Span.FindIndex(UInt64.MaxValue, startIndex, count),
                () => singles.Array_.FindIndex(Single.MaxValue, startIndex, count),
                () => singles.S.Span.FindIndex(Single.MaxValue, startIndex, count),
                () => singles.R.Span.FindIndex(Single.MaxValue, startIndex, count),
                () => doubles.Array_.FindIndex(Double.MaxValue, startIndex, count),
                () => doubles.S.Span.FindIndex(Double.MaxValue, startIndex, count),
                () => doubles.R.Span.FindIndex(Double.MaxValue, startIndex, count),
            };

            // Array_; underscore used to match width of S.Span / R.Span
            (T[] Array_, Memory<T> S, ReadOnlyMemory<T> R) CreateDataSource<T>(T value) where T : struct
            {
                var source = new T[length];
                if (valueIndex.HasValue)
                { source[valueIndex!.Value] = value; }
                return (source, source.AsMemory(), (ReadOnlyMemory<T>)source.AsMemory());
            }
        }
    }
}
