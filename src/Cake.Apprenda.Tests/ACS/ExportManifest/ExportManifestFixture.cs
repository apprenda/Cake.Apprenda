using Cake.Apprenda.ACS.ExportManifest;
using Cake.Apprenda.Tests.ACS.Fixtures;
using Cake.Testing;

namespace Cake.Apprenda.Tests.ACS.ExportManifest
{
    public sealed class ExportManifestFixture : CloudShellFixture<ExportManifestSettings>
    {
        public ExportManifestFixture()
        {
            this.Settings.AppAlias = "myAppAlias";
            this.Settings.VersionAlias = "v1";
            this.Settings.ManifestFile = "./path/to/manifest-file.xml";

            this.FileSystem.CreateFile("./path/to/existing.xml");
        }

        public void TargetExistingFile(bool overwrite = false)
        {
            this.Settings.Overwrite = overwrite;
            this.Settings.ManifestFile = "./path/to/existing.xml";
        }

        protected override void RunTool()
        {
            var tool = new Apprenda.ACS.ExportManifest.ExportManifest(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            tool.Execute(this.Settings);
        }
    }
}