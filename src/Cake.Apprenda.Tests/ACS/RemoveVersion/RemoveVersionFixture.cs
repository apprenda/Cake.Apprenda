using Cake.Apprenda.ACS.RemoveVersion;
using Cake.Apprenda.Tests.ACS.Fixtures;

namespace Cake.Apprenda.Tests.ACS.RemoveVersion
{
    public sealed class RemoveVersionFixture : CloudShellFixture<RemoveVersionSettings>
    {
        public RemoveVersionFixture()
        {
            this.Settings.AppAlias = "myAppAlias";
            this.Settings.VersionAlias = "v1";
        }

        protected override void RunTool()
        {
            var tool = new Apprenda.ACS.RemoveVersion.RemoveVersion(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            tool.Execute(this.Settings);
        }
    }
}