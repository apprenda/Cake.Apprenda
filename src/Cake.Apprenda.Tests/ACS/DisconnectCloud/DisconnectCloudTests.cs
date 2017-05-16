using Cake.Apprenda.ACS.DisconnectCloud;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.DisconnectCloud
{
    public sealed class DisconnectCloudTests : CloudShellCommandTestBase<Apprenda.ACS.DisconnectCloud.DisconnectCloud, DisconnectCloudSettings, DisconnectCloudFixture>
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new DisconnectCloudFixture { Settings = null };

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsArgumentNullException(result, "settings");
        }

        [Fact]
        public void Should_Format_Arguments_Correctly()
        {
            // Given
            var fixture = new DisconnectCloudFixture();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("DisconnectCloud --NonInteractive -Y", result.Args);
        }
    }
}
