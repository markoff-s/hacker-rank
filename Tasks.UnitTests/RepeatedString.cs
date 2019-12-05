using System.Linq;
using FluentAssertions;
using Xunit;

namespace Tasks.UnitTests
{
    public class RepeatedString
    {
        [Theory]
        [InlineData("abcac", 10, 4)]
        [InlineData("aba", 10, 7)]
        [InlineData("a", 1000000000000, 1000000000000)]
        [InlineData("ababbbbbaa", 99, 39)]
        [InlineData("kmretasscityylpdhuwjirnqimlkcgxubxmsxpypgzxtenweirknjtasxtvxemtwxuarabssvqdnktqadhyktagjxoanknhgilnm", 
            736778906400, 51574523448)]
        public void CountNumberOfAs_InRepeatedString(string s, long n, long res)
        {
            var result = Count(s, n);

            result.Should().Be(res);
        }

        private static long Count(string s, long n)
        {
            var totalNumberOfAs = 0L;

            var str = s;
            var strLength = str.Length;
            var numberOfAsInStr = CountAs(str);
            var targetStrLength = n;
            
            var numberOfStrInTargetLength = targetStrLength / strLength;
            totalNumberOfAs += numberOfStrInTargetLength * numberOfAsInStr;

            // per task, str.Length is between 1 and 100, so it's safe to cast to int here
            var numberOfRemainingChars = (int)(targetStrLength % strLength);
            var numberOfAsInRemainingChars = CountAs(str.Substring(0, numberOfRemainingChars));
            totalNumberOfAs += numberOfAsInRemainingChars;

            return totalNumberOfAs;
        }

        private static int CountAs(string str)
        {
            return str.ToCharArray().Count(_ => _ == 'a');
        }
    }
}