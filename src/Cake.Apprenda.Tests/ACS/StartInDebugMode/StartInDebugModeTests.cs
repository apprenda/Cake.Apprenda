using Cake.Apprenda.ACS.StartInDebugMode;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.StartInDebugMode
{
    public sealed class StartInDebugModeTests : CloudShellCommandTestBase<Apprenda.ACS.StartInDebugMode.StartInDebugMode, StartInDebugModeSettings, StartInDebugModeFixture>
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new StartInDebugModeFixture { Settings = null };

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsArgumentNullException(result, "settings");
        }

        [Fact]
        public void Should_Throw_If_AppAlias_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new StartInDebugModeFixture();
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
            var fixture = new StartInDebugModeFixture();
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
            var fixture = new StartInDebugModeFixture();
            
            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("StartInDebugMode --NonInteractive -AppAlias \"myAppAlias\" -VersionAlias v1", result.Args);
        }

        [Fact]
        public void Should_Format_Arguments_Correctly_When_ComponentAlias_Is_Specified()
        {
            // Given
            var fixture = new StartInDebugModeFixture();
            fixture.Settings.ComponentAlias = "myComponent";

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("StartInDebugMode --NonInteractive -AppAlias \"myAppAlias\" -VersionAlias v1 -ComponentAlias \"myComponent\"", result.Args);
        }
    }
}
