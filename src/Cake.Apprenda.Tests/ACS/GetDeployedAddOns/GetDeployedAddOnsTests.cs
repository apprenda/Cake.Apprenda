using Cake.Apprenda.ACS.GetDeployedAddOns;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.GetDeployedAddOns
{
    public sealed class GetDeployedAddOnsTests : CloudShellCommandTestBase<Apprenda.ACS.GetDeployedAddOns.GetDeployedAddOns, GetDeployedAddOnsSettings, GetDeployedAddOnsFixture>
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new GetDeployedAddOnsFixture { Settings = null };

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsArgumentNullException(result, "settings");
        }

        [Fact]
        public void Should_Format_Arguments_Correctly()
        {
            // Given
            var fixture = new GetDeployedAddOnsFixture();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("GetDeployedAddOns", result.Args);
        }
    }
}
