using Cake.Apprenda.ACS.ProvisionAddOn;
using Cake.Apprenda.Tests.ACS.Fixtures;

namespace Cake.Apprenda.Tests.ACS.ProvisionAddOn
{
    public sealed class ProvisionAddOnFixture : CloudShellFixture<ProvisionAddOnSettings>
    {
        public ProvisionAddOnFixture()
        {
            this.Settings.Alias = "addOnAlias";
            this.Settings.InstanceAlias = "instanceAlias";
        }

        protected override void RunTool()
        {
            var tool = new Apprenda.ACS.ProvisionAddOn.ProvisionAddOn(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            tool.Execute(this.Settings);
        }
    }
}