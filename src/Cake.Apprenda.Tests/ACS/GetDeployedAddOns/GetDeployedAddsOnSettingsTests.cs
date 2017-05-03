using Cake.Apprenda.ACS.GetDeployedAddOns;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.GetDeployedAddOn
{
    public sealed class GetDeployedAddsOnSettingsTests : CloudShellSettingsTestsBase<GetDeployedAddOnsSettings>
    {
        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            Constructor(() => new GetDeployedAddOnsSettings()).ShouldNotThrow();
        }
    }
}
