using System;
using FluentAssertions;
using Xunit;

namespace Tasks.UnitTests
{
    public class MinMaxSum
    {
        [Theory]
        [InlineData(new long[] { 1, 3, 5, 7, 9 }, new long[] {16, 24})]
        public void CountMinMaxSum(long[] arr, long[] expected)
        {
            var result = Count(arr);

            for (var i = 0; i < result.Length; i++)
            {
                result[i].Should().Be(expected[i]);
            }
        }

        private static long[] Count(long[] arr)
        {
            var arrLength = arr.Length;
            var sums = new long[arrLength];

            for (var i = 0; i < arrLength; i++)
            {
                var currentSum = 0L;
                for (var j = 0; j < arrLength; j++)
                {
                    if (j == i) continue;

                    currentSum += arr[j];
                }

                sums[i] = currentSum;
            }

            Array.Sort(sums);
            var min = sums[0];
            var max = sums[^1];
            var minMax = new[] { min, max };

            return minMax;
        }
    }
}