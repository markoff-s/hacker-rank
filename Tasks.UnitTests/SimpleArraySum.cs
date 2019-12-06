using System.Linq;
using FluentAssertions;
using Xunit;

namespace Tasks.UnitTests
{
    public class SimpleArraySum
    {
        [Theory]
        [InlineData(new[] {10, 20, 20, 10, 10, 30, 50, 10, 20}, 180)]
        public void CalcSimpleArraySum(int[] arr, int res)
        {
            var result = arr.Sum();

            result.Should().Be(res);
        }
    }
}