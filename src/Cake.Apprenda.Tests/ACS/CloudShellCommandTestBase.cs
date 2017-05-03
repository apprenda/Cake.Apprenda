using Cake.Apprenda.Tests.ACS.Fixtures;
using Cake.Core.Tooling;
using Cake.Testing;
using Xunit;

namespace Cake.Apprenda.Tests.ACS
{
    public class CloudShellCommandTestBase<TCommand, TSettings, TFixture>
        where TSettings : ToolSettings, new()
        where TFixture : CloudShellFixture<TSettings>, new()
    {
        [Theory]
        [InlineData("/bin/upack/upack.exe", "/bin/upack/upack.exe")]
        [InlineData("./upack/upack.exe", "/Working/upack/upack.exe")]
        public void Should_Use_UPack_Executable_From_Tool_Path_If_Provided(string toolPath, string expected)
        {
            // Given
            var fixture = new TFixture { Settings = { ToolPath = toolPath } };
            fixture.GivenSettingsToolPathExist();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal(expected, result.Path.FullPath);
        }

        [Fact]
        public void Should_Throw_If_UPack_Executable_Was_Not_Found()
        {
            // Given
            var fixture = new TFixture();
            fixture.GivenDefaultToolDoNotExist();

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Apprenda ACS: Could not locate executable.");
        }

        [Fact]
        public void Should_Throw_If_Process_Was_Not_Started()
        {
            // Given
            var fixture = new TFixture();
            fixture.GivenProcessCannotStart();

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Apprenda ACS: Process was not started.");
        }

        [Fact]
        public void Should_Throw_If_Process_Has_A_Non_Zero_Exit_Code()
        {
            // Given
            var fixture = new TFixture();
            fixture.GivenProcessExitsWithCode(1);

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Apprenda ACS: Process returned an error (exit code 1).");
        }
    }
}
