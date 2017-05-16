using Cake.Apprenda.ACS.ExportArchive;
using Cake.Apprenda.Tests.ACS.Fixtures;
using Cake.Testing;

namespace Cake.Apprenda.Tests.ACS.ExportArchive
{
    public sealed class ExportArchiveFixture : CloudShellFixture<ExportArchiveSettings>
    {
        public ExportArchiveFixture()
        {
            this.Settings.AppAlias = "myAppAlias";
            this.Settings.VersionAlias = "v1";
            this.Settings.ArchiveFile = "./path/to/archive.zip";

            this.FileSystem.CreateFile("./path/to/existing.zip");
        }

        public void TargetExistingFile(bool overwrite = false)
        {
            this.Settings.Overwrite = overwrite;
            this.Settings.ArchiveFile = "./path/to/existing.zip";
        }

        protected override void RunTool()
        {
            var tool = new Apprenda.ACS.ExportArchive.ExportArchive(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            tool.Execute(this.Settings);
        }
    }
}