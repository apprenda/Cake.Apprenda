using Cake.Apprenda.ACS.StartInDebugMode;
using Cake.Apprenda.Tests.ACS.Fixtures;

namespace Cake.Apprenda.Tests.ACS.StartInDebugMode
{
    public sealed class StartInDebugModeFixture : CloudShellFixture<StartInDebugModeSettings>
    {
        public StartInDebugModeFixture()
        {
            this.Settings.AppAlias = "myAppAlias";
            this.Settings.VersionAlias = "v1";
        }

        protected override void RunTool()
        {
            var tool = new Apprenda.ACS.StartInDebugMode.StartInDebugMode(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            tool.Execute(this.Settings);
        }
    }
}