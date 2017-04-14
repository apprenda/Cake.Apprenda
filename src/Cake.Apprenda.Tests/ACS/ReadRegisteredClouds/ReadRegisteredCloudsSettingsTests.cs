using Cake.Apprenda.ACS.ReadRegisteredClouds;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.ReadRegisteredClouds
{
    public sealed class ReadRegisteredCloudsSettingsTests : ACSSettingsTestsBase<ReadRegisteredCloudsSettings>
    {
        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            Constructor(() => new ReadRegisteredCloudsSettings()).ShouldNotThrow();
        }
    }
}
