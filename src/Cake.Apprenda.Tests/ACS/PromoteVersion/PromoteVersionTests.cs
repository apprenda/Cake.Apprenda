using Cake.Apprenda.ACS.PromoteVersion;
using Xunit;
// ReSharper disable UseObjectOrCollectionInitializer

namespace Cake.Apprenda.Tests.ACS.PromoteVersion
{
    public sealed class PromoteVersionTests : CloudShellCommandTestBase<Apprenda.ACS.PromoteVersion.PromoteVersion, PromoteVersionSettings, PromoteVersionFixture>
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new PromoteVersionFixture { Settings = null };

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsArgumentNullException(result, "settings");
        }

        [Fact]
        public void Should_Throw_If_AppAlias_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new PromoteVersionFixture();
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
            var fixture = new PromoteVersionFixture();
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
            var fixture = new PromoteVersionFixture();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("PromoteVersion --NonInteractive -Y -AppAlias \"myAppAlias\" -VersionAlias v1", result.Args);
        }

        [Fact]
        public void Should_Format_Arguments_Correctly_Given_Stage()
        {
            // Given
            var fixture = new PromoteVersionFixture();
            fixture.Settings.Stage = ApplicationStage.Sandbox;

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("PromoteVersion --NonInteractive -Y -AppAlias \"myAppAlias\" -VersionAlias v1 -Stage Sandbox", result.Args);
        }
    }
}
