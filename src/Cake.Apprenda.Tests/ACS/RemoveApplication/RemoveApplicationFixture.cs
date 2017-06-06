using Cake.Apprenda.ACS.RemoveApplication;
using Cake.Apprenda.Tests.ACS.Fixtures;

namespace Cake.Apprenda.Tests.ACS.RemoveApplication
{
    public sealed class RemoveApplicationFixture : CloudShellFixture<RemoveApplicationSettings>
    {
        public RemoveApplicationFixture()
        {
            this.Settings.AppAlias = "myAppAlias";
        }

        protected override void RunTool()
        {
            var tool = new Apprenda.ACS.RemoveApplication.RemoveApplication(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            tool.Execute(this.Settings);
        }
    }
}