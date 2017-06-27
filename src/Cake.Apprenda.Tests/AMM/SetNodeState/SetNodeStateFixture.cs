using Cake.Apprenda.AMM;
using Cake.Apprenda.AMM.SetNodeState;
using Cake.Apprenda.Tests.AMM.Fixtures;

namespace Cake.Apprenda.Tests.AMM.SetNodeState
{
    public sealed class SetNodeStateFixture : MaintenanceModeFixture<SetNodeStateSettings>
    {
        public SetNodeStateFixture()
        {
            this.Settings.HostName = "cerberus";
            this.Settings.State = NodeState.Maintenance;
            this.Settings.Reason = "because it's broken";
        }

        protected override void RunTool()
        {
            var tool = new Apprenda.AMM.SetNodeState.SetNodeState(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            tool.Execute(this.Settings);
        }
    }
}