using Cake.Apprenda.ACS.StopVersion;
using Cake.Apprenda.Tests.ACS.Fixtures;

namespace Cake.Apprenda.Tests.ACS.StopVersion
{
    public sealed class StopVersionFixture : CloudShellFixture<StopVersionSettings>
    {
        public StopVersionFixture()
        {
            this.Settings.AppAlias = "myAppAlias";
            this.Settings.VersionAlias = "v1";
        }

        protected override void RunTool()
        {
            var tool = new Apprenda.ACS.StopVersion.StopVersion(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            tool.Execute(this.Settings);
        }
    }
}