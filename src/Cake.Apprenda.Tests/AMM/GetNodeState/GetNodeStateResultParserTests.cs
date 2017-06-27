using Cake.Apprenda.AMM;
using Cake.Apprenda.AMM.GetNodeState;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.AMM.GetNodeState
{
    public sealed class GetNodeStateResultParserTests
    {
        [Theory]
        [InlineData("The node state of WINCOMP01 is Online.", NodeState.Online)]
        [InlineData("The node state of WINCOMP01 is Reserved.", NodeState.Reserved)]
        [InlineData("The node state of WINCOMP01 is Maintenance.", NodeState.Maintenance)]
        public void ShouldParseNodeStateCorrectly(string output, NodeState expected)
        {
            // Given, When
            var result = new GetNodeStateResultParser().Parse(new[] { output });

            // Then
            result.Should().Be(expected);
        }

        [Fact]
        public void ShouldThrowWhenErrorIsRecognized()
        {
            // Given, When
            const string output = "An error occurred while executing the command 'GetNodeState'.  Response code: 500 - InternalServerError";
            var ex = Record.Exception(() => new GetNodeStateResultParser().Parse(new[] { output }));
            
            // Then
            Assert.IsCakeException(ex, "An error occured while executing command: Response code: 500 - InternalServerError");
        }

        [Fact]
        public void ShouldThrowWhenResultCannotBeParsed()
        {
            // Given, When
            const string output = "Whoah, something happened.";
            var ex = Record.Exception(() => new GetNodeStateResultParser().Parse(new[] { output }));

            // Then
            Assert.IsCakeException(ex, "Unable to parse response. Raw response was: Whoah, something happened.");
        }
    }
}
