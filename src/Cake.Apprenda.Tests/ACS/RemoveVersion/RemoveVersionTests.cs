using Cake.Apprenda.ACS.RemoveVersion;
using Xunit;
// ReSharper disable UseObjectOrCollectionInitializer

namespace Cake.Apprenda.Tests.ACS.RemoveVersion
{
    public sealed class RemoveVersionTests : CloudShellCommandTestBase<Apprenda.ACS.RemoveVersion.RemoveVersion, RemoveVersionSettings, RemoveVersionFixture>
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new RemoveVersionFixture { Settings = null };

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsArgumentNullException(result, "settings");
        }

        [Fact]
        public void Should_Throw_If_AppAlias_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new RemoveVersionFixture();
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
            var fixture = new RemoveVersionFixture();
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
            var fixture = new RemoveVersionFixture();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("RemoveVersion --NonInteractive -AppAlias myAppAlias -VersionAlias v1", result.Args);
        }
    }
}
