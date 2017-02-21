using Cake.Apprenda.ACS.DisconnectCloud;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.DisconnectCloud
{
    public sealed class DisconnectCloudSettingsTests : ACSSettingsTestsBase<DisconnectCloudSettings>
    {
        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            Constructor(() => new DisconnectCloudSettings()).ShouldNotThrow();
        }
    }
}
