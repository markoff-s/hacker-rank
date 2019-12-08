using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Tasks.UnitTests
{
    public class StairCase
    {
        private readonly ITestOutputHelper _output;

        public StairCase(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData(6)]
        [InlineData(10)]
        public void PrintStairCase(int n)
        {
            Print(n);
        }

        private void Print(int n)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < n; i++)
            {
                var numberOfWhitespaces = n - 1 - i;
                sb
                    .Append("".PadLeft(numberOfWhitespaces, ' '))
                    .Append("".PadRight(n - numberOfWhitespaces, '#'))
                    .AppendLine();
            }

            _output.WriteLine(sb.ToString());
        }
    }
}