using Cake.Apprenda.ACS.DemoteVersion;
using Cake.Apprenda.Tests.ACS.Fixtures;

namespace Cake.Apprenda.Tests.ACS.DemoteVersion
{
    public sealed class DemoteVersionFixture : CloudShellFixture<DemoteVersionSettings>
    {
        public DemoteVersionFixture()
        {
            this.Settings.AppAlias = "myAppAlias";
            this.Settings.VersionAlias = "v1";
        }

        protected override void RunTool()
        {
            var tool = new Apprenda.ACS.DemoteVersion.DemoteVersion(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            tool.Execute(this.Settings);
        }
    }
}