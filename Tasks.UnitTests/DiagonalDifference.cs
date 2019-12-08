using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Tasks.UnitTests
{
    public class DiagonalDifference
    {
        [Theory]
        [InlineData(3, 0)]
        [InlineData(5, 0)]
        public void CalcDiagonalDifference(int dimensionSize, int res)
        {
            var arr = new List<List<int>>(dimensionSize);
            for (var i = 0; i < dimensionSize; i++)
            {
                arr.Add(new List<int>());
                for (var j = 0; j < dimensionSize; j++)
                {
                    arr[i].Add(j + 1 + (i * dimensionSize));
                }
            }

            var result = CalcDiff(arr);

            result.Should().Be(res);
        }

        private static int CalcDiff(List<List<int>> arr)
        {
            var arrLength = arr[0].Count;
            var leftToRight = 0;
            var rightToLeft = 0;
            for (var i = 0; i < arrLength; i++)
            {
                leftToRight += arr[i][i];
                rightToLeft += arr[i][arrLength - 1 - i];
            }

            return Math.Abs(leftToRight - rightToLeft);
        }
    }
}