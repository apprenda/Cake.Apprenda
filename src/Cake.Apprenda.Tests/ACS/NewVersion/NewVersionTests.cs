using Cake.Apprenda.ACS;
using Cake.Apprenda.ACS.NewVersion;
using Xunit;
// ReSharper disable UseObjectOrCollectionInitializer

namespace Cake.Apprenda.Tests.ACS.NewVersion
{
    public sealed class NewVersionTests : CloudShellCommandTestBase<Apprenda.ACS.NewVersion.NewVersion, NewVersionSettings, NewVersionFixture>
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new NewVersionFixture { Settings = null };

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsArgumentNullException(result, "settings");
        }

        [Fact]
        public void Should_Throw_If_AppAlias_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new NewVersionFixture();
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
            var fixture = new NewVersionFixture();
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
            var fixture = new NewVersionFixture();
            fixture.Settings.ArchivePath = "./path/to/archive.zip";
            fixture.Settings.SolutionPath = "./path/to/solution.sln";

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "ArchivePath and SolutionPath cannot be used together in the same operation. Please specify one or the other.");
        }

        [Fact]
        public void Should_Throw_If_Stage_Is_Specified_Without_ArchivePath_Or_SolutionPath()
        {
            // Given
            var fixture = new NewVersionFixture();
            fixture.Settings.ArchivePath = null;
            fixture.Settings.SolutionPath = null;
            fixture.Settings.Stage = ApplicationStage.Sandbox;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Stage can only be used when ArchivePath or SolutionPath are specified.");
        }

        [Fact]
        public void Should_Throw_If_Solution_File_Does_Not_Exist()
        {
            // Given
            var fixture = new NewVersionFixture();
            fixture.Settings.SolutionPath = "./path/to/bad-solution.sln";

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "File 'path/to/bad-solution.sln' specified for SolutionPath argument does not exist.");
        }

        [Fact]
        public void Should_Throw_If_Archive_File_Does_Not_Exist()
        {
            // Given
            var fixture = new NewVersionFixture();
            fixture.Settings.ArchivePath = "./path/to/bad-archive.zip";

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "File 'path/to/bad-archive.zip' specified for ArchivePath argument does not exist.");
        }

        [Fact]
        public void Should_Format_Required_Arguments_Correctly()
        {
            // Given
            var fixture = new NewVersionFixture();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("NewVersion --NonInteractive -AppAlias \"myAppAlias\" -VersionAlias v2", result.Args);
        }

        [Fact]
        public void Should_Format_Arguments_Correctly()
        {
            // Given
            var fixture = new NewVersionFixture();
            fixture.Settings.VersionName = "version 2";
            fixture.Settings.Description = "my description";
            fixture.Settings.IsConstructive = true;
            fixture.Settings.ArchiveOutput = "./path/to/archive-out.zip";

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("NewVersion --NonInteractive -AppAlias \"myAppAlias\" -VersionAlias v2 -VersionName \"version 2\" -Description \"my description\" -Constructive -O \"path/to/archive-out.zip\"", result.Args);
        }
        [Theory]
        [InlineData(null, "")]
        [InlineData(ApplicationStage.Definition, "")] // definition is suppressed, it's the default and becomes redundant
        [InlineData(ApplicationStage.Sandbox, " -Stage Sandbox")]
        [InlineData(ApplicationStage.Published, " -Stage Published")]
        public void Should_Format_Arguments_Correctly_When_SolutionPath_Is_Set(ApplicationStage? stage, string expected)
        {
            // Given
            var fixture = new NewVersionFixture();
            fixture.Settings.Stage = stage;
            fixture.Settings.SolutionPath = "./path/to/solution.sln";
            fixture.Settings.BuildSettings = new BuildSettings { RebuildSolution = true, Configuration = "Release" };

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal($"NewVersion --NonInteractive -AppAlias \"myAppAlias\" -VersionAlias v2{expected} -Path \"path/to/solution.sln\" -B -Config \"Release\"", result.Args);
        }

        [Theory]
        [InlineData(null, "")]
        [InlineData(ApplicationStage.Definition, "")] // definition is suppressed, it's the default and becomes redundant
        [InlineData(ApplicationStage.Sandbox, " -Stage Sandbox")]
        [InlineData(ApplicationStage.Published, " -Stage Published")]
        public void Should_Format_Arguments_Correctly_When_ArchivePath_Is_Set(ApplicationStage? stage, string expected)
        {
            // Given
            var fixture = new NewVersionFixture();
            fixture.Settings.Stage = stage;
            fixture.Settings.ArchivePath = "./path/to/archive.zip";

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal($"NewVersion --NonInteractive -AppAlias \"myAppAlias\" -VersionAlias v2{expected} -Package \"path/to/archive.zip\"", result.Args);
        }
    }
}
