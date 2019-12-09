using System;
using FluentAssertions;
using Xunit;

namespace Tasks.UnitTests
{
    public class BirthdayCakeCandles
    {
        [Theory]
        [InlineData(new[] { 1, 3, 5, 7, 9, 4, 3, 9 }, 2)]
        public void CountBirthdayCakeCandles(int[] arr, int expected)
        {
            var result = Count(arr);

            result.Should().Be(expected);
        }

        private static int Count(int[] arr)
        {
            Array.Sort(arr);
            var arrLength = arr.Length;
            var max = arr[arrLength - 1];
            var counter = 1;

            var i = arrLength - 2;
            while (i >= 0 && arr[i] == max)
            {
                counter++;
                i--;
            }

            return counter;
        }
    }
}