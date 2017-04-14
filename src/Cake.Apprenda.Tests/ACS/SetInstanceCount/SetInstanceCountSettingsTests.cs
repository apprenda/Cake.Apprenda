using System;
using Cake.Apprenda.ACS.SetInstanceCount;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.SetInstanceCount
{
    public sealed class SetInstanceCountSettingsTests : ACSSettingsTestsBase<SetInstanceCountSettings>
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenAppAliasIsNullOrEmpty(string appAlias)
        {
            Constructor(() => new SetInstanceCountSettings(appAlias, "versionAlias", "componentAlias", Scale.Up(1))).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("appAlias");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenVersionAliasIsNullOrEmpty(string versionAlias)
        {
            Constructor(() => new SetInstanceCountSettings("appalias", versionAlias, "componentAlias", Scale.Up(1))).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("versionAlias");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenComponentAliasIsNullOrEmpty(string componentAlias)
        {
            Constructor(() => new SetInstanceCountSettings("appalias", "versionAlias", componentAlias, Scale.Up(1))).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("componentAlias");
        }

        [Theory]
        [InlineData(null)]
        public void TheCtorShouldThrowWhenScalingExpressionIsNull(ScalingExpression scalingExpression)
        {
            Constructor(() => new SetInstanceCountSettings("appalias", "v1", "componentAlias", scalingExpression)).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("expression");
        }

        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            Constructor(() => new SetInstanceCountSettings("appalias", "v1", "componentAlias", Scale.Up(1))).ShouldNotThrow();
        }

        [Fact]
        public void TheScalingExpressionShouldNotBeNull()
        {
            var settings = new SetInstanceCountSettings("appalias", "v1", "componentAlias", Scale.Up(1));
            settings.ScalingExpression.Should().NotBeNull();
        }
    }
}
