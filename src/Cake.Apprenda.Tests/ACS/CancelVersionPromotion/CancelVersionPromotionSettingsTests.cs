using System;
using Cake.Apprenda.ACS.CancelVersionPromotion;
using FluentAssertions;
using Xunit;

// ReSharper disable NotAccessedVariable

namespace Cake.Apprenda.Tests.ACS.CancelVersionPromotion
{
    public sealed class CancelVersionPromotionSettingsTests : ACSSettingsTestsBase<CancelVersionPromotionSettings>
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenAppAliasIsNullOrEmpty(string appAlias)
        {
            this.Constructor(() => new CancelVersionPromotionSettings(appAlias, "versionAlias")).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("appAlias");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenVersionAliasIsNullOrEmpty(string versionAlias)
        {
            this.Constructor(() => new CancelVersionPromotionSettings("appalias", versionAlias)).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("versionAlias");
        }

        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            this.Constructor(() => new CancelVersionPromotionSettings("myapp", "v1")).ShouldNotThrow();
        }
    }
}
