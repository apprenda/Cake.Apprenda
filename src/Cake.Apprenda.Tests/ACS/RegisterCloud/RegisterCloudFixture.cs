using Cake.Apprenda.ACS.RegisterCloud;
using Cake.Apprenda.Tests.ACS.Fixtures;

namespace Cake.Apprenda.Tests.ACS.RegisterCloud
{
    public sealed class RegisterCloudFixture : CloudShellFixture<RegisterCloudSettings>
    {
        public RegisterCloudFixture()
        {
            this.Settings.CloudAlias = "myCloud";
            this.Settings.CloudUrl = "http://apps.apprenda.mycloud/";
        }

        protected override void RunTool()
        {
            var tool = new Apprenda.ACS.RegisterCloud.RegisterCloud(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            tool.Execute(this.Settings);
        }
    }
}