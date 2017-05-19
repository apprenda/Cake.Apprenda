using Cake.Apprenda.ACS;
using Cake.Apprenda.ACS.PatchVersion;
using Xunit;
// ReSharper disable UseObjectOrCollectionInitializer

namespace Cake.Apprenda.Tests.ACS.PatchVersion
{
    public sealed class PatchVersionTests : CloudShellCommandTestBase<Apprenda.ACS.PatchVersion.PatchVersion, PatchVersionSettings, PatchVersionFixture>
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new PatchVersionFixture { Settings = null };

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsArgumentNullException(result, "settings");
        }

        [Fact]
        public void Should_Throw_If_AppAlias_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new PatchVersionFixture();
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
            var fixture = new PatchVersionFixture();
            fixture.Settings.VersionAlias = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting VersionAlias not specified.");
        }

        [Fact]
        public void Should_Throw_If_ArchivePath_And_SolutionPath_Are_Specified()
        {
            // Given
            var fixture = new PatchVersionFixture();
            fixture.Settings.ArchivePath = "./path/to/archive.zip";
            fixture.Settings.SolutionPath = "./path/to/solution.sln";

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "ArchivePath and SolutionPath cannot be used together in the same operation. Please specify one or the other.");
        }

        [Fact]
        public void Should_Throw_If_Neither_ArchivePath_Or_SolutionPath_Are_Specified()
        {
            // Given
            var fixture = new PatchVersionFixture();
            fixture.Settings.ArchivePath = null;
            fixture.Settings.SolutionPath = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Either ArchivePath or SolutionPath must be specified.");
        }

        [Fact]
        public void Should_Throw_If_Solution_File_Does_Not_Exist()
        {
            // Given
            var fixture = new PatchVersionFixture();
            fixture.Settings.SolutionPath = "./path/to/bad-solution.sln";
            fixture.Settings.ArchivePath = null; // turn this off, mutually exclusive.

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "File 'path/to/bad-solution.sln' specified for SolutionPath argument does not exist.");
        }

        [Fact]
        public void Should_Throw_If_Archive_File_Does_Not_Exist()
        {
            // Given
            var fixture = new PatchVersionFixture();
            fixture.Settings.ArchivePath = "./path/to/bad-archive.zip";

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "File 'path/to/bad-archive.zip' specified for ArchivePath argument does not exist.");
        }

        [Fact]
        public void Should_Format_Arguments_Correctly_Given_An_Archive()
        {
            // Given
            var fixture = new PatchVersionFixture();
            fixture.Settings.AppAlias = "myAppAlias";
            fixture.Settings.VersionAlias = "v2";
            fixture.Settings.NewVersionAlias = "v3";
            fixture.Settings.NewVersionName = "version 3";
            fixture.Settings.Stage = ApplicationStage.Sandbox;
            fixture.Settings.IsConstructive = true;
            fixture.Settings.ArchiveOutput = "./path/to/archive-out.zip";
            fixture.Settings.BuildSettings = new BuildSettings { Configuration = "Release", RebuildSolution = true };

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("PatchVersion --NonInteractive -AppAlias \"myAppAlias\" -VersionAlias v2 -NewVersionAlias \"v3\" -NewVersionName \"version 3\" -Stage Sandbox -Package \"path/to/archive.zip\" -Constructive -O \"path/to/archive-out.zip\"", result.Args);
        }

        [Fact]
        public void Should_Format_Arguments_Correctly_Given_A_Solution()
        {
            // Given
            var fixture = new PatchVersionFixture();
            fixture.Settings.AppAlias = "myAppAlias";
            fixture.Settings.VersionAlias = "v2";
            fixture.Settings.NewVersionAlias = "v3";
            fixture.Settings.NewVersionName = "version 3";
            fixture.Settings.Stage = ApplicationStage.Sandbox;
            fixture.Settings.IsConstructive = true;
            fixture.Settings.ArchiveOutput = "./path/to/archive-out.zip";

            fixture.Settings.ArchivePath = null;
            fixture.Settings.SolutionPath = "./path/to/solution.sln";

            fixture.Settings.BuildSettings = new BuildSettings { Configuration = "Release", RebuildSolution = true };

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("PatchVersion --NonInteractive -AppAlias \"myAppAlias\" -VersionAlias v2 -NewVersionAlias \"v3\" -NewVersionName \"version 3\" -Stage Sandbox -Path \"path/to/solution.sln\" -B -Configuration \"Release\" -Constructive -O \"path/to/archive-out.zip\"", result.Args);
        }
    }
}
