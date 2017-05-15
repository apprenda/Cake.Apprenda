using Cake.Apprenda.ACS.ConnectCloud;
using Cake.Apprenda.Tests.ACS.Fixtures;

namespace Cake.Apprenda.Tests.ACS.ConnectCloud
{
    public sealed class ConnectCloudFixture : CloudShellFixture<ConnectCloudSettings>
    {
        public ConnectCloudFixture()
        {
            this.Settings.CloudAlias = "myCloudAlias";
            this.Settings.User = "user@apprenda.com";
            this.Settings.Password = "p@ssword";
        }

        protected override void RunTool()
        {
            var tool = new Apprenda.ACS.ConnectCloud.ConnectCloud(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            tool.Execute(this.Settings);
        }
    }
}