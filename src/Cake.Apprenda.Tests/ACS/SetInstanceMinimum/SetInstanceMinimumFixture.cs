using Cake.Apprenda.ACS.SetInstanceMinimum;
using Cake.Apprenda.Tests.ACS.Fixtures;

namespace Cake.Apprenda.Tests.ACS.SetInstanceMinimum
{
    public sealed class SetInstanceMinimumFixture : CloudShellFixture<SetInstanceMinimumSettings>
    {
        public SetInstanceMinimumFixture()
        {
            this.Settings.AppAlias = "myAppAlias";
            this.Settings.ComponentAlias = "myComponent";
            this.Settings.VersionAlias = "v1";
            this.Settings.MinimumCount = 1;
        }

        protected override void RunTool()
        {
            var tool = new Apprenda.ACS.SetInstanceMinimum.SetInstanceMinimum(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            tool.Execute(this.Settings);
        }
    }
}