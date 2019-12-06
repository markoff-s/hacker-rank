using System.Linq;
using FluentAssertions;
using Xunit;

namespace Tasks.UnitTests
{
    public class AVeryBigSum
    {
        [Theory]
        [InlineData(new long[] { 1000000001, 1000000002, 1000000003, 1000000004, 1000000005}, 5000000015)]
        public void Calc_Very_Big_Sum(long[] arr, long res)
        {
            var result = arr.Sum();

            result.Should().Be(res);
        }
    }
}