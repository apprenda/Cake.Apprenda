using Cake.Apprenda.ACS.PromoteVersion;
using Cake.Apprenda.Tests.ACS.Fixtures;

namespace Cake.Apprenda.Tests.ACS.PromoteVersion
{
    public sealed class PromoteVersionFixture : CloudShellFixture<PromoteVersionSettings>
    {
        public PromoteVersionFixture()
        {
            this.Settings.AppAlias = "myAppAlias";
            this.Settings.VersionAlias = "v1";
        }

        protected override void RunTool()
        {
            var tool = new Apprenda.ACS.PromoteVersion.PromoteVersion(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            tool.Execute(this.Settings);
        }
    }
}