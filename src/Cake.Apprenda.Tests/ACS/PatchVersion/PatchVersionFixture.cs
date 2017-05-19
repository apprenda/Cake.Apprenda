using Cake.Apprenda.ACS.PatchVersion;
using Cake.Apprenda.Tests.ACS.Fixtures;
using Cake.Testing;

namespace Cake.Apprenda.Tests.ACS.PatchVersion
{
    public sealed class PatchVersionFixture : CloudShellFixture<PatchVersionSettings>
    {
        public PatchVersionFixture()
        {
            this.Settings.AppAlias = "myAppAlias";
            this.Settings.VersionAlias = "v2";
            this.Settings.ArchivePath = "./path/to/archive.zip";

            this.FileSystem.CreateFile("./path/to/archive.zip");
            this.FileSystem.CreateFile("./path/to/solution.sln");
        }

        protected override void RunTool()
        {
            var tool = new Apprenda.ACS.PatchVersion.PatchVersion(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            tool.Execute(this.Settings);
        }
    }
}