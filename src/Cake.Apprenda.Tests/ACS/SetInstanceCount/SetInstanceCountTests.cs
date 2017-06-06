using Cake.Apprenda.ACS.SetInstanceCount;
using Xunit;
// ReSharper disable UseObjectOrCollectionInitializer

namespace Cake.Apprenda.Tests.ACS.SetInstanceCount
{
    public sealed class SetInstanceCountTests : CloudShellCommandTestBase<Apprenda.ACS.SetInstanceCount.SetInstanceCount, SetInstanceCountSettings, SetInstanceCountFixture>
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new SetInstanceCountFixture { Settings = null };

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsArgumentNullException(result, "settings");
        }

        [Fact]
        public void Should_Throw_If_AppAlias_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new SetInstanceCountFixture();
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
            var fixture = new SetInstanceCountFixture();
            fixture.Settings.VersionAlias = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting VersionAlias not specified.");
        }

        [Fact]
        public void Should_Throw_If_ComponentAlias_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new SetInstanceCountFixture();
            fixture.Settings.ComponentAlias = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting ComponentAlias not specified.");
        }

        [Fact]
        public void Should_Throw_If_ScalingExpression_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new SetInstanceCountFixture();
            fixture.Settings.ScalingExpression = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting ScalingExpression not specified.");
        }

        [Fact]
        public void Should_Format_Arguments_Correctly()
        {
            // Given
            var fixture = new SetInstanceCountFixture();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("SetInstanceCount --NonInteractive -AppAlias \"myAppAlias\" -VersionAlias v1 -Component myComponent 4", result.Args);
        }
    }
}
