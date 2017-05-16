using Cake.Apprenda.ACS.NewApplication;
using Cake.Apprenda.Tests.ACS.Fixtures;
using Cake.Testing;

namespace Cake.Apprenda.Tests.ACS.NewApplication
{
    public sealed class NewApplicationFixture : CloudShellFixture<NewApplicationSettings>
    {
        public NewApplicationFixture()
        {
            this.Settings.AppName = "My App Name";
            this.Settings.AppAlias = "myAppAlias";

            this.FileSystem.CreateFile("./path/to/archive.zip");
            this.FileSystem.CreateFile("./path/to/solution.sln");
        }

        protected override void RunTool()
        {
            var tool = new Apprenda.ACS.NewApplication.NewApplication(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            tool.Execute(this.Settings);
        }
    }
}