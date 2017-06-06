using Cake.Apprenda.ACS.StopDebugMode;
using Cake.Apprenda.Tests.ACS.Fixtures;

namespace Cake.Apprenda.Tests.ACS.StopDebugMode
{
    public sealed class StopDebugModeFixture : CloudShellFixture<StopDebugModeSettings>
    {
        public StopDebugModeFixture()
        {
            this.Settings.AppAlias = "myAppAlias";
            this.Settings.VersionAlias = "v1";
        }

        protected override void RunTool()
        {
            var tool = new Apprenda.ACS.StopDebugMode.StopDebugMode(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            tool.Execute(this.Settings);
        }
    }
}