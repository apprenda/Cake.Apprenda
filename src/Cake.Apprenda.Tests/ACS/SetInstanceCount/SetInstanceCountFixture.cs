using Cake.Apprenda.ACS.SetInstanceCount;
using Cake.Apprenda.Tests.ACS.Fixtures;

namespace Cake.Apprenda.Tests.ACS.SetInstanceCount
{
    public sealed class SetInstanceCountFixture : CloudShellFixture<SetInstanceCountSettings>
    {
        public SetInstanceCountFixture()
        {
            this.Settings.AppAlias = "myAppAlias";
            this.Settings.ComponentAlias = "myComponent";
            this.Settings.VersionAlias = "v1";
            this.Settings.ScalingExpression = Scale.To(4);
        }

        protected override void RunTool()
        {
            var tool = new Apprenda.ACS.SetInstanceCount.SetInstanceCount(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            tool.Execute(this.Settings);
        }
    }
}