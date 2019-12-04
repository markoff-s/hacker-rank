using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Tasks.UnitTests
{
    public class SockMerchant
    {
        [Theory]
        [InlineData(new[] {10, 20, 20, 10, 10, 30, 50, 10, 20}, 3)]
        [InlineData(new[] {1, 1, 3, 1, 2, 1, 3, 3, 3, 3}, 4)]
        public void CountSocksPairs(int[] arr, int res)
        {
            var result = Count(arr);

            result.Should().Be(res);
        }

        private static int Count(int[] ar)
        {
            var dict = new Dictionary<int, int>();
            for (var i = 0; i < ar.Length; i++)
            {
                var currentSockColor = ar[i];
                if (!dict.ContainsKey(currentSockColor))
                    dict[currentSockColor] = 0;

                dict[currentSockColor]++;
            }

            var result = dict.Values.Sum(_ => { int tmp = _ / 2; return tmp; });

            return result;
        }
    }
}