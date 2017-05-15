using Cake.Apprenda.ACS.DeProvisionAddOn;
using Cake.Apprenda.Tests.ACS.Fixtures;

namespace Cake.Apprenda.Tests.ACS.DeProvisionAddOn
{
    public sealed class DeProvisionAddOnFixture : CloudShellFixture<DeProvisionAddOnSettings>
    {
        public DeProvisionAddOnFixture()
        {
            this.Settings.Alias = "myAddOn";
            this.Settings.InstanceAlias = "myInstance";
        }

        protected override void RunTool()
        {
            var tool = new Cake.Apprenda.ACS.DeProvisionAddOn.DeProvisionAddOn(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            tool.Execute(this.Settings);
        }
    }
}