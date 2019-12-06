using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Tasks.UnitTests
{
    public class CompareTriplets
    {
        [Theory]
        [InlineData(new[] {1, 2, 3}, new[] { 3, 2, 1 }, new[] { 1, 1 })]
        [InlineData(new[] { 17, 28, 30 }, new[] { 99, 16, 8 }, new[] { 2, 1 })]
        public void Compare_Triplets(int[] a, int[] b, int[] res)
        {
            var result = Compare(a.ToList(), b.ToList());

            result.Should().Equal(res.ToList());
        }

        private static List<int> Compare(List<int> a, List<int> b)
        {
            var alice = 0;
            var bob = 0;
            for (var i = 0; i < a.Count; i++)
            {
                if (a[i] > b[i])
                {
                    alice++;
                }
                else if (a[i] < b[i])
                {
                    bob++;
                }
            }

            return new List<int> {alice, bob};
        }
    }
}