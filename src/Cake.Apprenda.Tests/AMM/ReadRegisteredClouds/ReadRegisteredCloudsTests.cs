using Cake.Apprenda.AMM.ReadRegisteredClouds;
using Xunit;

namespace Cake.Apprenda.Tests.AMM.ReadRegisteredClouds
{
    public sealed class ReadRegisteredCloudsTests : MaintenanceModeCommandTestBase<Apprenda.AMM.ReadRegisteredClouds.ReadRegisteredClouds, ReadRegisteredCloudsSettings, ReadRegisteredCloudsFixture>
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new ReadRegisteredCloudsFixture { Settings = null };

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsArgumentNullException(result, "settings");
        }

        [Fact]
        public void Should_Format_Arguments_Correctly()
        {
            // Given
            var fixture = new ReadRegisteredCloudsFixture();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("ReadRegisteredClouds", result.Args);
        }
    }
}
