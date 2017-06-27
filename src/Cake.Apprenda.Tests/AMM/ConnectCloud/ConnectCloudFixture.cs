using Cake.Apprenda.AMM.ConnectCloud;
using Cake.Apprenda.Tests.AMM.Fixtures;

namespace Cake.Apprenda.Tests.AMM.ConnectCloud
{
    public sealed class ConnectCloudFixture : MaintenanceModeFixture<ConnectCloudSettings>
    {
        public ConnectCloudFixture()
        {
            this.Settings.CloudAlias = "myCloudAlias";
            this.Settings.User = "user@apprenda.com";
            this.Settings.Password = "p@ssword";
        }

        protected override void RunTool()
        {
            var tool = new Apprenda.AMM.ConnectCloud.ConnectCloud(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            tool.Execute(this.Settings);
        }
    }
}