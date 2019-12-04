using System;
using FluentAssertions;
using Xunit;

namespace Tasks.UnitTests
{
    public class CountingValleys
    {
        [Theory]
        [InlineData("UDDDUU", 1)]
        [InlineData("DDUUDDUDUUUD", 2)]
        public void CountValleys(string s, int res)
        {
            var result = Count(s);

            result.Should().Be(res);
        }

        private static int Count(string s)
        {
            var steps = s.ToCharArray();
            var valleysCount = 0;
            var currentLevel = 0;

            foreach (var step in steps)
            {
                var isStepUp = step == 'U';
                if (isStepUp)
                    currentLevel++;
                else
                    currentLevel--;

                if (isStepUp && currentLevel == 0)
                    valleysCount++;
            }

            return valleysCount;
        }
    }
}
