using System.Collections.Generic;
using Cake.Apprenda.ACS.ProvisionAddOn;
using Xunit;
// ReSharper disable UseObjectOrCollectionInitializer

namespace Cake.Apprenda.Tests.ACS.ProvisionAddOn
{
    public sealed class ProvisionAddOnTests : CloudShellCommandTestBase<Apprenda.ACS.ProvisionAddOn.ProvisionAddOn, ProvisionAddOnSettings, ProvisionAddOnFixture>
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new ProvisionAddOnFixture { Settings = null };

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsArgumentNullException(result, "settings");
        }

        [Fact]
        public void Should_Throw_If_Alias_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new ProvisionAddOnFixture();
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
            var fixture = new ProvisionAddOnFixture();
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
            var fixture = new ProvisionAddOnFixture();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("ProvisionAddOn --NonInteractive -Alias \"addOnAlias\" -InstanceAlias instanceAlias", result.Args);
        }

        [Fact]
        public void Should_Format_Arguments_Correctly_Given_Options()
        {
            // Given
            var fixture = new ProvisionAddOnFixture();
            fixture.Settings.Options = "my options here";

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("ProvisionAddOn --NonInteractive -Alias \"addOnAlias\" -InstanceAlias instanceAlias -Options \"my options here\"", result.Args);
        }

        [Fact]
        public void Should_Format_Arguments_Correctly_Given_Options_And_Parameters()
        {
            // Given
            var fixture = new ProvisionAddOnFixture();
            fixture.Settings.Options = "my options here";
            fixture.Settings.Parameters = new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value 2" } };

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("ProvisionAddOn --NonInteractive -Alias \"addOnAlias\" -InstanceAlias instanceAlias -Options \"my options here\" -Params -key1 \"value1\" -key2 \"value 2\"", result.Args);
        }
    }
}
