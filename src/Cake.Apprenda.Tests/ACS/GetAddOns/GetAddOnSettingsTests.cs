using Cake.Apprenda.ACS.GetAddOns;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.GetAddOns
{
    public sealed class GetAddOnSettingsTests : CloudShellSettingsTestsBase<GetAddOnsSettings>
    {
        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            Constructor(() => new GetAddOnsSettings()).ShouldNotThrow();
        }
    }
}
