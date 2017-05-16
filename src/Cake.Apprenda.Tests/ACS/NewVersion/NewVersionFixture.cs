using Cake.Apprenda.ACS.NewVersion;
using Cake.Apprenda.Tests.ACS.Fixtures;
using Cake.Testing;

namespace Cake.Apprenda.Tests.ACS.NewVersion
{
    public sealed class NewVersionFixture : CloudShellFixture<NewVersionSettings>
    {
        public NewVersionFixture()
        {
            this.FileSystem.CreateFile("./path/to/solution.sln");
            this.FileSystem.CreateFile("./path/to/archive.zip");

            this.Settings.AppAlias = "myAppAlias";
            this.Settings.VersionAlias = "v2";
        }

        protected override void RunTool()
        {
            var tool = new Apprenda.ACS.NewVersion.NewVersion(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            tool.Execute(this.Settings);
        }
    }
}