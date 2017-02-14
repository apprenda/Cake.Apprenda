using System;
using Cake.Apprenda.ACS.CancelVersionPromotion;
using FluentAssertions;
using Xunit;
// ReSharper disable NotAccessedVariable

namespace Cake.Apprenda.Tests.ACS.CancelVersionPromotion
{
    public sealed class CancelVersionPromotionSettingsTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenAppAliasIsNullOrEmpty(string appAlias)
        {
            CancelVersionPromotionSettings settings;
            Action action = () => settings = new CancelVersionPromotionSettings(appAlias, "v1");
            action.ShouldThrow<ArgumentException>().And.ParamName.Should().Be("appAlias");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenVersionAliasIsNullOrEmpty(string versionAlias)
        {
            CancelVersionPromotionSettings settings;
            Action action = () => settings = new CancelVersionPromotionSettings("appalias", versionAlias);
            action.ShouldThrow<ArgumentException>().And.ParamName.Should().Be("versionAlias");
        }
    }
}
