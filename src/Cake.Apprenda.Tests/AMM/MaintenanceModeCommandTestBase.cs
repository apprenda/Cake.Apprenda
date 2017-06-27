using Cake.Apprenda.Tests.AMM.Fixtures;
using Cake.Core.Tooling;
using Cake.Testing;
using Xunit;
// ReSharper disable UseObjectOrCollectionInitializer

namespace Cake.Apprenda.Tests.AMM
{
    public abstract class MaintenanceModeCommandTestBase<TCommand, TSettings, TFixture>
        where TCommand : Tool<TSettings>
        where TSettings : ToolSettings, new()
        where TFixture : MaintenanceModeFixture<TSettings>, new()
    {
        [Theory]
        [InlineData("/bin/amm/amm.exe", "/bin/amm/amm.exe")]
        [InlineData("./amm/amm.exe", "/Working/amm/amm.exe")]
        public void Should_Use_AMM_Executable_From_Tool_Path_If_Provided(string toolPath, string expected)
        {
            // Given
            var fixture = new TFixture();
            fixture.Settings.ToolPath = toolPath;
            fixture.GivenSettingsToolPathExist();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal(expected, result.Path.FullPath);
        }

        [Fact]
        public void Should_Throw_If_AMM_Executable_Was_Not_Found()
        {
            // Given
            var fixture = new TFixture();
            fixture.GivenDefaultToolDoNotExist();

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Apprenda AMM: Could not locate executable.");
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
            Assert.IsCakeException(result, "Apprenda AMM: Process was not started.");
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
            Assert.IsCakeException(result, "Apprenda AMM: Process returned an error (exit code 1).");
        }
    }
}
