using Cake.Apprenda.AMM.DisconnectCloud;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.AMM.DisconnectCloud
{
    public sealed class DisconnectCloudSettingsTests : MaintenanceModeSettingsTestsBase<DisconnectCloudSettings>
    {
        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            this.Constructor(() => new DisconnectCloudSettings()).ShouldNotThrow();
        }
    }
}
