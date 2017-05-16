using System.Collections.Generic;
using Cake.Apprenda.ACS.GetDeployedAddOns;
using Cake.Apprenda.Tests.ACS.Fixtures;

namespace Cake.Apprenda.Tests.ACS.GetDeployedAddOns
{
    public sealed class GetDeployedAddOnsFixture : CloudShellFixture<GetDeployedAddOnsSettings>
    {
        protected override void RunTool()
        {
            var tool = new Apprenda.ACS.GetDeployedAddOns.GetDeployedAddOns(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            this.Result = tool.Execute(this.Settings);
        }

        public IEnumerable<DeployedAddOnInfo> Result { get; set; }
    }
}