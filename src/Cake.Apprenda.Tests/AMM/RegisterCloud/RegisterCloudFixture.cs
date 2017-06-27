using Cake.Apprenda.AMM.RegisterCloud;
using Cake.Apprenda.Tests.AMM.Fixtures;

namespace Cake.Apprenda.Tests.AMM.RegisterCloud
{
    public sealed class RegisterCloudFixture : MaintenanceModeFixture<RegisterCloudSettings>
    {
        public RegisterCloudFixture()
        {
            this.Settings.CloudAlias = "myCloud";
            this.Settings.CloudUrl = "http://apps.apprenda.mycloud/";
        }

        protected override void RunTool()
        {
            var tool = new Apprenda.AMM.RegisterCloud.RegisterCloud(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            tool.Execute(this.Settings);
        }
    }
}