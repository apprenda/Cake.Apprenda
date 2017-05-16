using Cake.Apprenda.ACS.NewPackage;
using Cake.Apprenda.Tests.ACS.Fixtures;
using Cake.Testing;

namespace Cake.Apprenda.Tests.ACS.NewPackage
{
    public sealed class NewPackageFixture : CloudShellFixture<NewPackageSettings>
    {
        public NewPackageFixture()
        {
            this.FileSystem.CreateFile("./path/to/solution.sln");

            this.Settings.SolutionPath = "./path/to/solution.sln";
            this.Settings.ArchiveOutput = "./path/to/archive.zip";
        }

        protected override void RunTool()
        {
            var tool = new Apprenda.ACS.NewPackage.NewPackage(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            tool.Execute(this.Settings);
        }
    }
}