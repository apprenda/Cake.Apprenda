using Cake.Apprenda.ACS.StartVersion;
using Cake.Apprenda.Tests.ACS.Fixtures;

namespace Cake.Apprenda.Tests.ACS.StartVersion
{
    public sealed class StartVersionFixture : CloudShellFixture<StartVersionSettings>
    {
        public StartVersionFixture()
        {
            this.Settings.AppAlias = "myAppAlias";
            this.Settings.VersionAlias = "v1";
        }

        protected override void RunTool()
        {
            var tool = new Apprenda.ACS.StartVersion.StartVersion(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            tool.Execute(this.Settings);
        }
    }
}