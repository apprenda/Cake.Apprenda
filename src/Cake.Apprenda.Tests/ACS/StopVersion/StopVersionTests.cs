using Cake.Apprenda.ACS.StopVersion;
using Xunit;
// ReSharper disable UseObjectOrCollectionInitializer

namespace Cake.Apprenda.Tests.ACS.StopVersion
{
    public sealed class StopVersionTests : CloudShellCommandTestBase<Apprenda.ACS.StopVersion.StopVersion, StopVersionSettings, StopVersionFixture>
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new StopVersionFixture { Settings = null };

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsArgumentNullException(result, "settings");
        }

        [Fact]
        public void Should_Throw_If_AppAlias_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new StopVersionFixture();
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
            var fixture = new StopVersionFixture();
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
            var fixture = new StopVersionFixture();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("StopVersion --NonInteractive -Y -AppAlias \"myAppAlias\" -VersionAlias v1", result.Args);
        }
    }
}
