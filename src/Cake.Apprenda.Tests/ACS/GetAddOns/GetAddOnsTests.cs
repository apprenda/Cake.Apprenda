using Xunit;

namespace Cake.Apprenda.Tests.ACS.GetAddOns
{
    public sealed class GetAddOnsTests
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new GetAddOnsFixture { Settings = null };

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsArgumentNullException(result, "settings");
        }

        [Fact]
        public void Should_Format_Arguments_Correctly()
        {
            // Given
            var fixture = new GetAddOnsFixture();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("GetAddOns", result.Args);
        }
    }
}
