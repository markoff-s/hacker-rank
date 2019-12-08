using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Tasks.UnitTests
{
    public class PlusMinus
    {
        [Theory]
        [InlineData(new[] { -4, 3, -9, 0, 4, 1 }, new[] {0.5, 0.333333, 0.166667})]
        public void CountPlusMinusZeroRatio(int[] arr, double[] expected)
        {
            var result = Count(arr);

            for (var i = 0; i < expected.Length; i++)
            {
                var tmp = Math.Round(Convert.ToDecimal(expected[i]), 6);
                result[i].Should().Be(tmp);
            }
        }

        private static decimal[] Count(int[] arr)
        {
            var pos = 0d;
            var neg = 0d;
            var zero = 0d;

            foreach (var t in arr)
            {
                if (t > 0)
                    pos++;
                else if (t < 0)
                    neg++;
                else
                    zero++;
            }

            var posRatio = Math.Round(Convert.ToDecimal(pos / arr.Length), 6);
            var negRatio = Math.Round(Convert.ToDecimal(neg / arr.Length), 6);
            var zeroRatio = Math.Round(Convert.ToDecimal(zero / arr.Length), 6);
            var decimals = new[] { posRatio, negRatio, zeroRatio };

            return decimals;
        }
    }
}