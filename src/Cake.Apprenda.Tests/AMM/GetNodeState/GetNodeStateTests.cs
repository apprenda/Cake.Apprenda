using Cake.Apprenda.AMM.GetNodeState;
using Xunit;

// ReSharper disable UseObjectOrCollectionInitializer

namespace Cake.Apprenda.Tests.AMM.GetNodeState
{
    public sealed class GetNodeStateTests : MaintenanceModeCommandTestBase<Apprenda.AMM.GetNodeState.GetNodeState, GetNodeStateSettings, GetNodeStateFixture>
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new GetNodeStateFixture { Settings = null };

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsArgumentNullException(result, "settings");
        }
        
        [Fact]
        public void Should_Throw_If_HostName_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new GetNodeStateFixture();
            fixture.Settings.HostName = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting HostName not specified.");
        }

        [Fact]
        public void Should_Format_Arguments_Correctly()
        {
            // Given
            var fixture = new GetNodeStateFixture();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("GetNodeState --NonInteractive -Hostname cerberus", result.Args);
        }
    }
}
