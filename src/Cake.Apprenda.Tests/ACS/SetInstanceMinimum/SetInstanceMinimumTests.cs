using Cake.Apprenda.ACS.SetInstanceMinimum;
using Xunit;
// ReSharper disable UseObjectOrCollectionInitializer

namespace Cake.Apprenda.Tests.ACS.SetInstanceMinimum
{
    public sealed class SetInstanceMinimumTests : CloudShellCommandTestBase<Apprenda.ACS.SetInstanceMinimum.SetInstanceMinimum, SetInstanceMinimumSettings, SetInstanceMinimumFixture>
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new SetInstanceMinimumFixture { Settings = null };

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsArgumentNullException(result, "settings");
        }

        [Fact]
        public void Should_Throw_If_AppAlias_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new SetInstanceMinimumFixture();
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
            var fixture = new SetInstanceMinimumFixture();
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
            var fixture = new SetInstanceMinimumFixture();
            fixture.Settings.ComponentAlias = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting ComponentAlias not specified.");
        }

        [Fact]
        public void Should_Throw_If_InstanceCount_Is_Less_Than_One()
        {
            // Given
            var fixture = new SetInstanceMinimumFixture();
            fixture.Settings.MinimumCount = 0;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Minimum count must be at least 1 instance.");
        }

        [Fact]
        public void Should_Format_Arguments_Correctly()
        {
            // Given
            var fixture = new SetInstanceMinimumFixture();
            fixture.Settings.MinimumCount = 12;

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("SetInstanceMinimum --NonInteractive -AppAlias \"myAppAlias\" -VersionAlias v1 -Component \"myComponent\" -MinCount 12", result.Args);
        }
    }
}
