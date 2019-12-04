using FluentAssertions;
using Xunit;

namespace Tasks.UnitTests
{
    public class JumpingOnTheClouds
    {
        [Theory]
        [InlineData(new[] { 0, 0, 1, 0, 0, 1, 0 }, 4)]
        [InlineData(new[] { 0, 0, 0, 0, 1, 0 }, 3)]
        [InlineData(new[] { 0, 1, 0, 0, 0, 1, 0 }, 3)]
        [InlineData(new[] { 0, 0 }, 1)]
        [InlineData(new[] { 0, 0, 0 }, 1)]
        [InlineData(new[] { 0, 0, 0, 1, 0 }, 2)]
        public void CountShortestPath(int[] arr, int res)
        {
            var result = Count(arr);

            result.Should().Be(res);
        }

        private static int Count(int[] arr)
        {
            var numberOfHops = 0;
            var arrLength = arr.Length;
            var i = 0;
            while (i < arrLength)
            {
                // try 2 steps forward
                var currentIndex = i + 2;
                if (currentIndex < arrLength && arr[currentIndex] == 0)
                {
                    numberOfHops++;
                    i = currentIndex;
                    continue;
                }

                // step back
                currentIndex--;
                if (currentIndex < arrLength && arr[currentIndex] == 0)
                {
                    numberOfHops++;
                    i = currentIndex;
                }

                // last element
                if (i >= arrLength - 1) break;
            }

            return numberOfHops;
        }
    }
}