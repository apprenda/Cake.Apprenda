using Cake.Apprenda.AMM.DisconnectCloud;
using Cake.Apprenda.Tests.AMM.Fixtures;

namespace Cake.Apprenda.Tests.AMM.DisconnectCloud
{
    public sealed class DisconnectCloudFixture : MaintenanceModeFixture<DisconnectCloudSettings>
    {
        protected override void RunTool()
        {
            var tool = new Apprenda.AMM.DisconnectCloud.DisconnectCloud(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            tool.Execute(this.Settings);
        }
    }
}