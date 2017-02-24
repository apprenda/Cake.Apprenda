using System;
using Cake.Apprenda.ACS.DeProvisionAddOn;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.DeProvisionAddOn
{
    public sealed class DeProvisionAddOnSettingsTests : ACSSettingsTestsBase<DeProvisionAddOnSettings>
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenAliasIsNullOrEmpty(string alias)
        {
            Constructor(() => new DeProvisionAddOnSettings(alias, "instanceAlias")).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("alias");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenInstanceAliasIsNullOrEmpty(string instanceAlias)
        {
            Constructor(() => new DeProvisionAddOnSettings("alias", instanceAlias)).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("instanceAlias");
        }

        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            Constructor(() => new DeProvisionAddOnSettings("alias", "instanceAlias")).ShouldNotThrow();
        }
    }
}
