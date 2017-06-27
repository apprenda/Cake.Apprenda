using Cake.Apprenda.AMM.ReadRegisteredClouds;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.AMM.ReadRegisteredClouds
{
    public sealed class ReadRegisteredCloudsSettingsTests : MaintenanceModeSettingsTestsBase<ReadRegisteredCloudsSettings>
    {
        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            this.Constructor(() => new ReadRegisteredCloudsSettings()).ShouldNotThrow();
        }
    }
}
