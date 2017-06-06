using Cake.Apprenda.ACS.RemoveApplication;
using Xunit;
// ReSharper disable UseObjectOrCollectionInitializer

namespace Cake.Apprenda.Tests.ACS.RemoveApplication
{
    public sealed class RemoveApplicationTests : CloudShellCommandTestBase<Apprenda.ACS.RemoveApplication.RemoveApplication, RemoveApplicationSettings, RemoveApplicationFixture>
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new RemoveApplicationFixture { Settings = null };

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsArgumentNullException(result, "settings");
        }

        [Fact]
        public void Should_Throw_If_AppAlias_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new RemoveApplicationFixture();
            fixture.Settings.AppAlias = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting AppAlias not specified.");
        }

        [Fact]
        public void Should_Format_Arguments_Correctly()
        {
            // Given
            var fixture = new RemoveApplicationFixture();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("RemoveApplication --NonInteractive -AppAlias myAppAlias", result.Args);
        }
    }
}
