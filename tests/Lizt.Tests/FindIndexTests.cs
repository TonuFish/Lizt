using System;
using System.Runtime.Intrinsics.X86;
using FluentAssertions;
using Lizt.Extensions;
using Xunit;

namespace Lizt.Tests
{
    public class FindIndexTests
    {
        private const int NotFound = -1;

        // TODO: All test methods need a rewrite given Fody and removal of Lzcnt and Bmi1, plus actually being finished

#region ParameterTests

        [MemberData(nameof(ParameterTestData), 0, 0, 0)]
        [Theory(DisplayName = "Parameters: Throws when source is empty")]
        [Trait("Category", "Parameter")]
        public void Parameters_ThrowsWhenSourceIsEmpty(Func<int> methodCall)
        {
            methodCall.Should().Throw<Exception>("because the source contained no elements.");
        }

        [MemberData(nameof(ParameterTestData), 1, -1, 0)]
        [MemberData(nameof(ParameterTestData), 1, 1, 0)]
        [Theory(DisplayName = "Parameters: Throws when start index is out of range")]
        [Trait("Category", "Parameter")]
        public void Parameters_ThrowsWhenStartIndexOutOfRange(Func<int> methodCall)
        {
            methodCall.Should().Throw<ArgumentOutOfRangeException>("because startIndex was negative or g.t.e. source.Length.")
                .And.ParamName.Should().Be("startIndex");
        }

        [MemberData(nameof(ParameterTestData), 1, 0, 0)]
        [MemberData(nameof(ParameterTestData), 1, 0, 2)]
        [Theory(DisplayName = "Parameters: Throws when count is out of range")]
        [Trait("Category", "Parameter")]
        public void Parameters_ThrowsWhenCountOutOfRange(Func<int> methodCall)
        {
            methodCall.Should().Throw<ArgumentOutOfRangeException>("because count was not positive or (count+startIndex) g.t. source.Length")
                .And.ParamName.Should().Be("count");
        }

#endregion ParameterTests

#region ManualLoopTests

        // TODO: Clean up these tests
        // Disable appropriate instruction sets for each test type

        [MemberData(nameof(RunTestData), 100, 0, 100, new int[] { 14, 15 })]
        [MemberData(nameof(RunTestData), 100, 0, 100, new int[] { 15, 16 })]
        [MemberData(nameof(RunTestData), 100, 0, 100, new int[] { 16, 17 })]
        [MemberData(nameof(RunTestData), 100, 0, 100, new int[] { 30, 31 })]
        [MemberData(nameof(RunTestData), 100, 0, 100, new int[] { 31, 32 })]
        [MemberData(nameof(RunTestData), 100, 0, 100, new int[] { 32, 33 })]
        [Theory(DisplayName = "ManualLoop: Finds value on width boundary")]
        [Trait("Category", "ManualLoop")]
        public void ManualLoop_FindsFirstValueOnWidthBoundary(Func<int> methodCall, int[]? valueIndexes)
        {
            // Arrange
            int? result = null;
            Action act = () => result = methodCall.Invoke();

            // Act, Assert
            act.Should().NotThrow("because the paramaters are valid.");
            result.Should().Be(valueIndexes![0], "because it's the first occurrence of the search value.");
        }

        [MemberData(nameof(RunTestData), 100, 0, 100, null)]
        [Theory(DisplayName = "ManualLoop: Returns not found when value missing")]
        [Trait("Category", "ManualLoop")]
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters
        public void ManualLoop_ReturnsNotFoundWhenValueMissing(Func<int> methodCall, int[]? valueIndexes)
#pragma warning restore xUnit1026 // Theory methods should use all of their parameters
        {
            // Arrange
            int? result = null;
            Action act = () => result = methodCall.Invoke();

            // Act, Assert
            act.Should().NotThrow("because the paramaters are valid.");
            result.Should().Be(NotFound, "because the search value is not present.");
        }

#endregion ManualLoopTests

#region Vector128Tests

        [MemberData(nameof(RunTestData), 100, 0, 100, new int[] { 14, 15 })]
        [MemberData(nameof(RunTestData), 100, 0, 100, new int[] { 15, 16 })]
        [MemberData(nameof(RunTestData), 100, 0, 100, new int[] { 16, 17 })]
        [MemberData(nameof(RunTestData), 100, 0, 100, new int[] { 30, 31 })]
        [MemberData(nameof(RunTestData), 100, 0, 100, new int[] { 31, 32 })]
        [MemberData(nameof(RunTestData), 100, 0, 100, new int[] { 32, 33 })]
        [Theory(DisplayName = "Vector128: Finds value on width boundary")]
        [Trait("Category", "Vector128")]
        public void Vector128_FindsFirstValueOnWidthBoundary(Func<int> methodCall, int[]? valueIndexes)
        {
            // Validate
            Sse41.IsSupported.Should().BeTrue("because it's the minimum instruction set required to test all Vector128 implementations.");

            // Arrange
            int? result = null;
            Action act = () => result = methodCall.Invoke();

            // Act, Assert
            act.Should().NotThrow("because the paramaters are valid.");
            result.Should().Be(valueIndexes![0], "because it's the first occurrence of the search value.");
        }

        [MemberData(nameof(RunTestData), 100, 0, 100, null)]
        [Theory(DisplayName = "Vector128: Returns not found when value missing")]
        [Trait("Category", "Vector128")]
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters
        public void Vector128_ReturnsNotFoundWhenValueMissing(Func<int> methodCall, int[]? valueIndexes)
#pragma warning restore xUnit1026 // Theory methods should use all of their parameters
        {
            // Validate
            Sse41.IsSupported.Should().BeTrue("because it's the minimum instruction set required to test all Vector128 implementations.");

            // Arrange
            int? result = null;
            Action act = () => result = methodCall.Invoke();

            // Act, Assert
            act.Should().NotThrow("because the paramaters are valid.");
            result.Should().Be(NotFound, "because the search value is not present.");
        }

#endregion Vector128Tests

#region Vector256Tests

        [MemberData(nameof(RunTestData), 100, 0, 100, new int[] { 30, 31 })]
        [MemberData(nameof(RunTestData), 100, 0, 100, new int[] { 31, 32 })]
        [MemberData(nameof(RunTestData), 100, 0, 100, new int[] { 32, 33 })]
        [MemberData(nameof(RunTestData), 100, 0, 100, new int[] { 62, 63 })]
        [MemberData(nameof(RunTestData), 100, 0, 100, new int[] { 63, 64 })]
        [MemberData(nameof(RunTestData), 100, 0, 100, new int[] { 64, 65 })]
        [Theory(DisplayName = "Vector256: Finds value on width boundary")]
        [Trait("Category", "Vector256")]
        public void Vector256_FindsFirstValueOnWidthBoundary(Func<int> methodCall, int[]? valueIndexes)
        {
            // Validate
            Avx2.IsSupported.Should().BeTrue("because it's the minimum instruction set required to test all Vector256 implementations.");

            // Arrange
            int? result = null;
            Action act = () => result = methodCall.Invoke();

            // Act, Assert
            act.Should().NotThrow("because the paramaters are valid.");
            result.Should().Be(valueIndexes![0], "because it's the first occurrence of the search value.");
        }

        [MemberData(nameof(RunTestData), 100, 0, 100, null)]
        [Theory(DisplayName = "Vector256: Returns not found when value missing")]
        [Trait("Category", "Vector256")]
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters
        public void Vector256_ReturnsNotFoundWhenValueMissing(Func<int> methodCall, int[]? valueIndexes)
#pragma warning restore xUnit1026 // Theory methods should use all of their parameters
        {
            // Validate
            Avx2.IsSupported.Should().BeTrue("because it's the minimum instruction set required to test all Vector256 implementations.");

            // Arrange
            int? result = null;
            Action act = () => result = methodCall.Invoke();

            // Act, Assert
            act.Should().NotThrow("because the paramaters are valid.");
            result.Should().Be(NotFound, "because the search value is not present.");
        }

#endregion Vector256Tests

//#region IonadFody

//        // TODO: Figure how to handle these, compile time IF? Different test groups, different configurations? File includes/excludes?

//        [StaticReplacement(typeof(Avx2))]
//        public static class Avx2Substitute
//        {
//            public static bool IsSupported { get => false; }
//        }

//        [StaticReplacement(typeof(Sse41))]
//        public static class Sse41Substitute
//        {
//            public static bool IsSupported { get => false; }
//        }

//#endregion IonadFody

#region ArrangeTheoryData

        public static TheoryData<Func<int>> ParameterTestData(int length, int startIndex, int count)
        {
            var theoryData = new TheoryData<Func<int>>();
            PopulateTheoryData(length, startIndex, count, AddTheoryData);
            return theoryData;

            void AddTheoryData(Func<int> func) => theoryData.Add(func);
        }

        public static TheoryData<Func<int>, int[]?> RunTestData(int length, int startIndex, int count, int[]? valueIndexes)
        {
            var theoryData = new TheoryData<Func<int>, int[]?>();
            PopulateTheoryData(length, startIndex, count, AddTheoryData, valueIndexes);
            return theoryData;

            void AddTheoryData(Func<int> func) => theoryData.Add(func, valueIndexes);
        }

        private static void PopulateTheoryData(int length, int startIndex, int count, Action<Func<int>> addTheoryData, int[]? valueIndexes = null)
        {
            // TODO: This is **really** ugly. Fix this at some point.

            {
                var (a1, a2, a3) = SupplyArrays<Byte>(length, valueIndexes, Byte.MaxValue);
                addTheoryData.Invoke(() => a1.FindIndex(Byte.MaxValue, startIndex, count));
                addTheoryData.Invoke(() => a2.AsSpan().FindIndex(Byte.MaxValue, startIndex, count));
                addTheoryData.Invoke(() => ((ReadOnlySpan<Byte>)a3.AsSpan()).FindIndex(Byte.MaxValue, startIndex, count));
            }

            {
                var (a1, a2, a3) = SupplyArrays<SByte>(length, valueIndexes, SByte.MaxValue);
                addTheoryData.Invoke(() => a1.FindIndex(SByte.MaxValue, startIndex, count));
                addTheoryData.Invoke(() => a2.AsSpan().FindIndex(SByte.MaxValue, startIndex, count));
                addTheoryData.Invoke(() => ((ReadOnlySpan<SByte>)a3.AsSpan()).FindIndex(SByte.MaxValue, startIndex, count));
            }

            {
                var (a1, a2, a3) = SupplyArrays<Int16>(length, valueIndexes, Int16.MaxValue);
                addTheoryData.Invoke(() => a1.FindIndex(Int16.MaxValue, startIndex, count));
                addTheoryData.Invoke(() => a2.AsSpan().FindIndex(Int16.MaxValue, startIndex, count));
                addTheoryData.Invoke(() => ((ReadOnlySpan<Int16>)a3.AsSpan()).FindIndex(Int16.MaxValue, startIndex, count));
            }

            {
                var (a1, a2, a3) = SupplyArrays<UInt16>(length, valueIndexes, UInt16.MaxValue);
                addTheoryData.Invoke(() => a1.FindIndex(UInt16.MaxValue, startIndex, count));
                addTheoryData.Invoke(() => a2.AsSpan().FindIndex(UInt16.MaxValue, startIndex, count));
                addTheoryData.Invoke(() => ((ReadOnlySpan<UInt16>)a3.AsSpan()).FindIndex(UInt16.MaxValue, startIndex, count));
            }

            {
                var (a1, a2, a3) = SupplyArrays<Int32>(length, valueIndexes, Int32.MaxValue);
                addTheoryData.Invoke(() => a1.FindIndex(Int32.MaxValue, startIndex, count));
                addTheoryData.Invoke(() => a2.AsSpan().FindIndex(Int32.MaxValue, startIndex, count));
                addTheoryData.Invoke(() => ((ReadOnlySpan<Int32>)a3.AsSpan()).FindIndex(Int32.MaxValue, startIndex, count));
            }

            {
                var (a1, a2, a3) = SupplyArrays<UInt32>(length, valueIndexes, UInt32.MaxValue);
                addTheoryData.Invoke(() => a1.FindIndex(UInt32.MaxValue, startIndex, count));
                addTheoryData.Invoke(() => a2.AsSpan().FindIndex(UInt32.MaxValue, startIndex, count));
                addTheoryData.Invoke(() => ((ReadOnlySpan<UInt32>)a3.AsSpan()).FindIndex(UInt32.MaxValue, startIndex, count));
            }

            {
                var (a1, a2, a3) = SupplyArrays<Int64>(length, valueIndexes, Int64.MaxValue);
                addTheoryData.Invoke(() => a1.FindIndex(Int64.MaxValue, startIndex, count));
                addTheoryData.Invoke(() => a2.AsSpan().FindIndex(Int64.MaxValue, startIndex, count));
                addTheoryData.Invoke(() => ((ReadOnlySpan<Int64>)a3.AsSpan()).FindIndex(Int64.MaxValue, startIndex, count));
            }

            {
                var (a1, a2, a3) = SupplyArrays<UInt64>(length, valueIndexes, UInt64.MaxValue);
                addTheoryData.Invoke(() => a1.FindIndex(UInt64.MaxValue, startIndex, count));
                addTheoryData.Invoke(() => a2.AsSpan().FindIndex(UInt64.MaxValue, startIndex, count));
                addTheoryData.Invoke(() => ((ReadOnlySpan<UInt64>)a3.AsSpan()).FindIndex(UInt64.MaxValue, startIndex, count));
            }

            {
                var (a1, a2, a3) = SupplyArrays<Single>(length, valueIndexes, Single.MaxValue);
                addTheoryData.Invoke(() => a1.FindIndex(Single.MaxValue, startIndex, count));
                addTheoryData.Invoke(() => a2.AsSpan().FindIndex(Single.MaxValue, startIndex, count));
                addTheoryData.Invoke(() => ((ReadOnlySpan<Single>)a3.AsSpan()).FindIndex(Single.MaxValue, startIndex, count));
            }

            {
                var (a1, a2, a3) = SupplyArrays<Double>(length, valueIndexes, Double.MaxValue);
                addTheoryData.Invoke(() => a1.FindIndex(Double.MaxValue, startIndex, count));
                addTheoryData.Invoke(() => a2.AsSpan().FindIndex(Double.MaxValue, startIndex, count));
                addTheoryData.Invoke(() => ((ReadOnlySpan<Double>)a3.AsSpan()).FindIndex(Double.MaxValue, startIndex, count));
            }
        }

        private static (T[] A1, T[] A2, T[] A3) SupplyArrays<T>(int length, int[]? valueIndexes, T value = default) where T : struct
        {
            var array1 = new T[length];
            var array2 = new T[length];
            var array3 = new T[length];

            if (valueIndexes is not null)
            {
                foreach (var index in valueIndexes)
                {
                    // Not ideal
                    array1[index] = value;
                    array2[index] = value;
                    array3[index] = value;
                }
            }

            return (array1, array2, array3);
        }

#endregion ArrangeTheoryData
    }
}
