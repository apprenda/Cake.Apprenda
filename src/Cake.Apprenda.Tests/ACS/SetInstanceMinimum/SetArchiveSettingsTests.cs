using System;
using Cake.Apprenda.ACS.SetInstanceMinimum;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.SetInstanceMinimum
{
    public sealed class SetInstanceMinimumSettingsTests : CloudShellSettingsTestsBase<SetInstanceMinimumSettings>
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenAppAliasIsNullOrEmpty(string appAlias)
        {
            Constructor(() => new SetInstanceMinimumSettings(appAlias, "versionAlias", "componentAlias", 1)).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("appAlias");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenVersionAliasIsNullOrEmpty(string versionAlias)
        {
            Constructor(() => new SetInstanceMinimumSettings("appalias", versionAlias, "componentAlias", 1)).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("versionAlias");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenComponentAliasIsNullOrEmpty(string componentAlias)
        {
            Constructor(() => new SetInstanceMinimumSettings("appalias", "versionAlias", componentAlias, 1)).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("componentAlias");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void TheCtorShouldThrowWhenMinimumInstanceIsOutOfRange(int minimumInstanceCount)
        {
            Constructor(() => new SetInstanceMinimumSettings("appalias", "versionAlias", "componentAlias", minimumInstanceCount)).ShouldThrow<ArgumentOutOfRangeException>().And.ParamName.Should().Be("minimumCount");
        }

        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            Constructor(() => new SetInstanceMinimumSettings("appalias", "v1", "componentAlias", 1)).ShouldNotThrow();
        }
    }
}
