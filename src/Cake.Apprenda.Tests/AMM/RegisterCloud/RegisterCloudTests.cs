using Cake.Apprenda.AMM.RegisterCloud;
using Xunit;

// ReSharper disable UseObjectOrCollectionInitializer

namespace Cake.Apprenda.Tests.AMM.RegisterCloud
{
    public sealed class RegisterCloudTests : MaintenanceModeCommandTestBase<Apprenda.AMM.RegisterCloud.RegisterCloud, RegisterCloudSettings, RegisterCloudFixture>
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new RegisterCloudFixture { Settings = null };

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsArgumentNullException(result, "settings");
        }

        [Fact]
        public void Should_Throw_If_CloudAlias_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new RegisterCloudFixture();
            fixture.Settings.CloudAlias = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting CloudAlias not specified.");
        }

        [Fact]
        public void Should_Throw_If_CloudUrl_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new RegisterCloudFixture();
            fixture.Settings.CloudUrl = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting CloudUrl not specified.");
        }

        [Fact]
        public void Should_Format_Arguments_Correctly()
        {
            // Given
            var fixture = new RegisterCloudFixture();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("RegisterCloud --NonInteractive -Alias myCloud -Url http://apps.apprenda.mycloud/", result.Args);
        }
    }
}
