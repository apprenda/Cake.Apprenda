using Cake.Apprenda.ACS.StartVersion;
using Xunit;
// ReSharper disable UseObjectOrCollectionInitializer

namespace Cake.Apprenda.Tests.ACS.StartVersion
{
    public sealed class StartVersionTests : CloudShellCommandTestBase<Apprenda.ACS.StartVersion.StartVersion, StartVersionSettings, StartVersionFixture>
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new StartVersionFixture { Settings = null };

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsArgumentNullException(result, "settings");
        }

        [Fact]
        public void Should_Throw_If_AppAlias_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new StartVersionFixture();
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
            var fixture = new StartVersionFixture();
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
            var fixture = new StartVersionFixture();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("StartVersion --NonInteractive -Y -AppAlias \"myAppAlias\" -VersionAlias v1", result.Args);
        }

    }
}
