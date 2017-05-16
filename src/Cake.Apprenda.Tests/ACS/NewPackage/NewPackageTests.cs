using Cake.Apprenda.ACS.NewPackage;
using Xunit;
// ReSharper disable UseObjectOrCollectionInitializer

namespace Cake.Apprenda.Tests.ACS.NewPackage
{
    public sealed class NewPackageTests : CloudShellCommandTestBase<Apprenda.ACS.NewPackage.NewPackage, NewPackageSettings, NewPackageFixture>
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new NewPackageFixture { Settings = null };

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsArgumentNullException(result, "settings");
        }

        [Fact]
        public void Should_Throw_If_SolutionPath_Is_Null()
        {
            // Given
            var fixture = new NewPackageFixture();
            fixture.Settings.SolutionPath = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting SolutionPath not specified.");
        }

        [Fact]
        public void Should_Throw_If_ArchiveOutput_Is_Null()
        {
            // Given
            var fixture = new NewPackageFixture();
            fixture.Settings.ArchiveOutput = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting ArchiveOutput not specified.");
        }

        [Fact]
        public void Should_Throw_If_SolutionFile_Does_Not_Exist()
        {
            // Given
            var fixture = new NewPackageFixture();
            fixture.Settings.SolutionPath = "./path/to/bad-solution.sln";

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "File 'path/to/bad-solution.sln' specified for SolutionPath argument does not exist.");
        }

        [Fact]
        public void Should_Format_Arguments_Correctly()
        {
            // Given
            var fixture = new NewPackageFixture();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("NewPackage --NonInteractive -Sln \"path/to/solution.sln\" -O \"path/to/archive.zip\"", result.Args);
        }
    }
}
