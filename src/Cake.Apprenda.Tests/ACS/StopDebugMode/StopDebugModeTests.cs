using Cake.Apprenda.ACS.StopDebugMode;
using Xunit;
// ReSharper disable UseObjectOrCollectionInitializer

namespace Cake.Apprenda.Tests.ACS.StopDebugMode
{
    public sealed class StopDebugModeTests : CloudShellCommandTestBase<Apprenda.ACS.StopDebugMode.StopDebugMode, StopDebugModeSettings, StopDebugModeFixture>
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new StopDebugModeFixture { Settings = null };

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsArgumentNullException(result, "settings");
        }

        [Fact]
        public void Should_Throw_If_AppAlias_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new StopDebugModeFixture();
            fixture.Settings.AppAlias = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting AppAlias not specified.");
        }

        [Fact]
        public void Should_Throw_If_VersionAlias_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new StopDebugModeFixture();
            fixture.Settings.VersionAlias = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting VersionAlias not specified.");
        }

        [Fact]
        public void Should_Format_Arguments_Correctly()
        {
            // Given
            var fixture = new StopDebugModeFixture();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("StopDebugMode --NonInteractive -AppAlias \"myAppAlias\" -VersionAlias v1", result.Args);
        }

        [Fact]
        public void Should_Format_Arguments_Correctly_When_ComponentAlias_Is_Specified()
        {
            // Given
            var fixture = new StopDebugModeFixture();
            fixture.Settings.ComponentAlias = "myComponent";

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("StopDebugMode --NonInteractive -AppAlias \"myAppAlias\" -VersionAlias v1 -ComponentAlias \"myComponent\"", result.Args);
        }
    }
}
