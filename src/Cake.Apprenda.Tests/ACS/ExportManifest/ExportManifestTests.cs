using Cake.Apprenda.ACS.ExportManifest;
using Xunit;
// ReSharper disable UseObjectOrCollectionInitializer

namespace Cake.Apprenda.Tests.ACS.ExportManifest
{
    public sealed class ExportManifestTests : CloudShellCommandTestBase<Apprenda.ACS.ExportManifest.ExportManifest, ExportManifestSettings, ExportManifestFixture>
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new ExportManifestFixture { Settings = null };

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsArgumentNullException(result, "settings");
        }

        [Fact]
        public void Should_Throw_If_AppAlias_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new ExportManifestFixture();
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
            var fixture = new ExportManifestFixture();
            fixture.Settings.VersionAlias = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting VersionAlias not specified.");
        }

        [Fact]
        public void Should_Throw_If_ManifestFile_Is_Null()
        {
            // Given
            var fixture = new ExportManifestFixture();
            fixture.Settings.ManifestFile = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting ManifestFile not specified.");
        }

        [Fact]
        public void Should_Throw_If_ManifestFile_Already_Exists_And_Overwrite_Not_Specified()
        {
            // Given
            var fixture = new ExportManifestFixture();
            fixture.TargetExistingFile();

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "The manifest file specified at 'path/to/existing.xml' exists and the Overwrite option has not been specified.");
        }

        [Fact]
        public void Should_Format_Arguments_Correctly()
        {
            // Given
            var fixture = new ExportManifestFixture();
            fixture.Settings.Overwrite = true;

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("ExportManifest --NonInteractive -AppAlias \"myAppAlias\" -VersionAlias v1 -Manifest \"path/to/manifest-file.xml\" -Overwrite", result.Args);
        }
    }
}
