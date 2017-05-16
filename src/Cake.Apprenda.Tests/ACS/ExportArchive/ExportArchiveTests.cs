using Cake.Apprenda.ACS.ExportArchive;
using Xunit;
// ReSharper disable UseObjectOrCollectionInitializer

namespace Cake.Apprenda.Tests.ACS.ExportArchive
{
    public sealed class ExportArchiveTests : CloudShellCommandTestBase<Apprenda.ACS.ExportArchive.ExportArchive, ExportArchiveSettings, ExportArchiveFixture>
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new ExportArchiveFixture { Settings = null };

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsArgumentNullException(result, "settings");
        }

        [Fact]
        public void Should_Throw_If_AppAlias_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new ExportArchiveFixture();
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
            var fixture = new ExportArchiveFixture();
            fixture.Settings.VersionAlias = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting VersionAlias not specified.");
        }

        [Fact]
        public void Should_Throw_If_ArchiveFile_Is_Null()
        {
            // Given
            var fixture = new ExportArchiveFixture();
            fixture.Settings.ArchiveFile = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting ArchiveFile not specified.");
        }

        [Fact]
        public void Should_Throw_If_ArchiveFile_Is_Not_ZipFile()
        {
            // Given
            var fixture = new ExportArchiveFixture();
            fixture.Settings.ArchiveFile = "./path/to/archive.rar";

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "The archive file specified at 'path/to/archive.rar' does not appear to be a valid zip file name.");
        }

        [Fact]
        public void Should_Throw_If_ArchiveFile_Already_Exists_And_Overwrite_Not_Specified()
        {
            // Given
            var fixture = new ExportArchiveFixture();
            fixture.TargetExistingFile();

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "The archive file specified at 'path/to/existing.zip' exists and the Overwrite option has not been specified.");
        }

        [Fact]
        public void Should_Format_Arguments_Correctly()
        {
            // Given
            var fixture = new ExportArchiveFixture();
            fixture.Settings.Overwrite = true;
            fixture.Settings.ExcludeManifest = true;

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("ExportArchive --NonInteractive -AppAlias \"myAppAlias\" -VersionAlias v1 -Package \"path/to/archive.zip\" -Overwrite -ExcludeManifest", result.Args);
        }
    }
}
