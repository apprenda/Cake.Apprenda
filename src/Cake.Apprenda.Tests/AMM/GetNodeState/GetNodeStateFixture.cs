using Cake.Apprenda.AMM.GetNodeState;
using Cake.Apprenda.Tests.AMM.Fixtures;

namespace Cake.Apprenda.Tests.AMM.GetNodeState
{
    public sealed class GetNodeStateFixture : MaintenanceModeFixture<GetNodeStateSettings>
    {
        public GetNodeStateFixture()
        {
            this.Settings.HostName = "cerberus";
        }

        protected override void RunTool()
        {
            var tool = new Apprenda.AMM.GetNodeState.GetNodeState(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            tool.Execute(this.Settings);
        }
    }
}