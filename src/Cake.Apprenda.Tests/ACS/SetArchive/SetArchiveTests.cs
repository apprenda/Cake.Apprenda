using Cake.Apprenda.ACS;
using Cake.Apprenda.ACS.SetArchive;
using Cake.Apprenda.Tests.ACS.Fixtures;
using Cake.Testing;
using Xunit;
// ReSharper disable UseObjectOrCollectionInitializer

namespace Cake.Apprenda.Tests.ACS.SetArchive
{
    public sealed class SetArchiveFixture : CloudShellFixture<SetArchiveSettings>
    {
        public SetArchiveFixture()
        {
            Settings.AppAlias = "myAppAlias";
            Settings.VersionAlias = "v1";
            Settings.ArchivePath = "./path/to/archive.zip";

            this.FileSystem.CreateFile("./path/to/archive.zip");
            this.FileSystem.CreateFile("./path/to/solution.sln");
        }

        protected override void RunTool()
        {
            var tool = new Apprenda.ACS.SetArchive.SetArchive(FileSystem, Environment, ProcessRunner, Tools, Resolver);
            tool.Execute(Settings);
        }
    }

    public sealed class SetArchiveTests : CloudShellCommandTestBase<Apprenda.ACS.SetArchive.SetArchive, SetArchiveSettings, SetArchiveFixture>
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new SetArchiveFixture { Settings = null };

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsArgumentNullException(result, "settings");
        }

        [Fact]
        public void Should_Throw_If_AppAlias_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new SetArchiveFixture();
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
            var fixture = new SetArchiveFixture();
            fixture.Settings.VersionAlias = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting VersionAlias not specified.");
        }

        [Fact]
        public void Should_Throw_If_Archive_And_Solution_Are_Both_Set()
        {
            // Given
            var fixture = new SetArchiveFixture();
            fixture.Settings.ArchivePath = "./path/to/archive.zip";
            fixture.Settings.SolutionPath = "./path/to/solution.zip";

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "ArchivePath and SolutionPath cannot be used together in the same operation. Please specify one or the other.");
        }

        [Fact]
        public void Should_Throw_If_Neither_Archive_Nor_Solution_Are_Set()
        {
            // Given
            var fixture = new SetArchiveFixture();
            fixture.Settings.ArchivePath = null;
            fixture.Settings.SolutionPath = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "You must specify either ArchivePath or SolutionPath.");
        }

        [Fact]
        public void Should_Throw_If_Archive_FilePath_Does_Not_Exist()
        {
            // Given
            var fixture = new SetArchiveFixture();
            fixture.Settings.ArchivePath = "./path/to/bad-archive.zip";
            fixture.Settings.SolutionPath = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "File 'path/to/bad-archive.zip' specified for ArchivePath argument does not exist.");
        }

        [Fact]
        public void Should_Throw_If_Solution_FilePath_Does_Not_Exist()
        {
            // Given
            var fixture = new SetArchiveFixture();
            fixture.Settings.ArchivePath = null;
            fixture.Settings.SolutionPath = "./path/to/bad-solution.sln";

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "File 'path/to/bad-solution.sln' specified for SolutionPath argument does not exist.");
        }

        [Fact]
        public void Should_Format_Arguments_Correctly_For_Solution()
        {
            // Given
            var fixture = new SetArchiveFixture();

            fixture.Settings.ArchivePath = null;
            fixture.Settings.SolutionPath = "./path/to/solution.sln";
            fixture.Settings.IsConstructive = true;
            fixture.Settings.ArchiveOutput = "./path/to/archive-out.zip";

            fixture.Settings.BuildSettings = new BuildSettings
            {
                Configuration = "Release",
                RebuildSolution = true
            };

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("SetArchive --NonInteractive -AppAlias \"myAppAlias\" -VersionAlias v1 -Path \"path/to/solution.sln\" -B -Configuration \"Release\" -Constructive -O \"path/to/archive-out.zip\"", result.Args);
        }

        [Fact]
        public void Should_Format_Arguments_Correctly_For_Archive()
        {
            // Given
            var fixture = new SetArchiveFixture();
            fixture.Settings.ArchivePath = "./path/to/archive.zip";
            fixture.Settings.SolutionPath = null;

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("SetArchive --NonInteractive -AppAlias \"myAppAlias\" -VersionAlias v1 -Package \"path/to/archive.zip\"", result.Args);
        }
    }
}
