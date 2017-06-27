using Cake.Apprenda.AMM;
using Cake.Apprenda.AMM.SetNodeState;
using Xunit;
// ReSharper disable UseObjectOrCollectionInitializer

namespace Cake.Apprenda.Tests.AMM.SetNodeState
{
    public sealed class SetNodeStateTests : MaintenanceModeCommandTestBase<Apprenda.AMM.SetNodeState.SetNodeState, SetNodeStateSettings, SetNodeStateFixture>
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new SetNodeStateFixture() { Settings = null };

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsArgumentNullException(result, "settings");
        }

        [Fact]
        public void Should_Throw_If_HostName_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new SetNodeStateFixture();
            fixture.Settings.HostName = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting HostName not specified.");
        }

        [Fact]
        public void Should_Throw_If_State_Is_Unknown()
        {
            // Given
            var fixture = new SetNodeStateFixture();
            fixture.Settings.State = NodeState.Unknown;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Node state cannot be transitioned to 'Unknown'.");
        }

        [Fact]
        public void Should_Throw_If_State_Is_Invalid()
        {
            // Given
            var fixture = new SetNodeStateFixture();
            fixture.Settings.State = (NodeState)23;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Invalid node state value specified.");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_Throw_If_Reason_Is_Null_Or_Empty(string reason)
        {
            // Given
            var fixture = new SetNodeStateFixture();
            fixture.Settings.Reason = reason;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting Reason not specified.");
        }

        [Fact]
        public void Should_Format_Arguments_Correctly()
        {
            // Given
            var fixture = new SetNodeStateFixture();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("SetNodeState --NonInteractive -Hostname cerberus -State Maintenance -Reason \"because it's broken\"", result.Args);
        }
    }
}
