using System;
using Cake.Apprenda.ACS.ProvisionAddOn;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.ProvisionAddOn
{
    public sealed class ProvisionAddOnSettingsTests : ACSSettingsTestsBase<ProvisionAddOnSettings>
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenAliasIsNullOrEmpty(string alias)
        {
            Constructor(() => new ProvisionAddOnSettings(alias, "instanceAlias")).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("alias");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenInstanceAliasIsNullOrEmpty(string instanceAlias)
        {
            Constructor(() => new ProvisionAddOnSettings("alias", instanceAlias)).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("instanceAlias");
        }

        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            Constructor(() => new ProvisionAddOnSettings("alias", "instanceAlias")).ShouldNotThrow();
        }
    }
}
