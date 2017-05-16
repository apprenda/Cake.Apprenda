using Cake.Apprenda.ACS.DisconnectCloud;
using Cake.Apprenda.Tests.ACS.Fixtures;

namespace Cake.Apprenda.Tests.ACS.DisconnectCloud
{
    public sealed class DisconnectCloudFixture : CloudShellFixture<DisconnectCloudSettings>
    {
        protected override void RunTool()
        {
            var tool = new Apprenda.ACS.DisconnectCloud.DisconnectCloud(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            tool.Execute(this.Settings);
        }
    }
}