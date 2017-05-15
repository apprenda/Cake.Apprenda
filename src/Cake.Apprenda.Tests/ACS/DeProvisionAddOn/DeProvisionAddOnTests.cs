using Cake.Apprenda.ACS.DeProvisionAddOn;
using Xunit;
// ReSharper disable UseObjectOrCollectionInitializer

namespace Cake.Apprenda.Tests.ACS.DeProvisionAddOn
{
    public sealed class DeProvisionAddOnTests : CloudShellCommandTestBase<Apprenda.ACS.DeProvisionAddOn.DeProvisionAddOn, DeProvisionAddOnSettings, DeProvisionAddOnFixture>
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new DeProvisionAddOnFixture { Settings = null };

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsArgumentNullException(result, "settings");
        }

        [Fact]
        public void Should_Throw_If_Alias_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new DeProvisionAddOnFixture();
            fixture.Settings.Alias = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting Alias not specified.");
        }

        [Fact]
        public void Should_Throw_If_InstanceAlias_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new DeProvisionAddOnFixture();
            fixture.Settings.InstanceAlias = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting InstanceAlias not specified.");
        }

        [Fact]
        public void Should_Format_Arguments_Correctly()
        {
            // Given
            var fixture = new DeProvisionAddOnFixture();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("DeProvisionAddOn --NonInteractive -Y -Alias \"myAddOn\" -InstanceAlias myInstance", result.Args);
        }
    }
}
