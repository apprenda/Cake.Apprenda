using Cake.Apprenda.AMM.ConnectCloud;
using Xunit;
// ReSharper disable UseObjectOrCollectionInitializer

namespace Cake.Apprenda.Tests.AMM.ConnectCloud
{
    public sealed class ConnectCloudTests : MaintenanceModeCommandTestBase<Apprenda.AMM.ConnectCloud.ConnectCloud, ConnectCloudSettings, ConnectCloudFixture>
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new ConnectCloudFixture { Settings = null };

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsArgumentNullException(result, "settings");
        }

        [Fact]
        public void Should_Throw_If_CloudAlias_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new ConnectCloudFixture();
            fixture.Settings.CloudAlias = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting CloudAlias not specified.");
        }

        [Fact]
        public void Should_Throw_If_User_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new ConnectCloudFixture();
            fixture.Settings.User = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting User not specified.");
        }

        [Fact]
        public void Should_Throw_If_Password_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new ConnectCloudFixture();
            fixture.Settings.Password = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting Password not specified.");
        }

        [Fact]
        public void Should_Format_Arguments_Correctly()
        {
            // Given
            var fixture = new ConnectCloudFixture();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("ConnectCloud --NonInteractive -CloudAlias myCloudAlias -User user@apprenda.com -Password p@ssword", result.Args);
        }
    }
}
