using System.Collections.Generic;
using System.Linq;
using Cake.Apprenda.ACS.GetAddOns;
using Cake.Apprenda.Tests.ACS.Fixtures;

namespace Cake.Apprenda.Tests.ACS.GetAddOns
{
    public sealed class GetAddOnsFixture : CloudShellFixture<GetAddOnsSettings>
    {
        public GetAddOnsFixture()
        {
            this.Result = Enumerable.Empty<AddOnInfo>();
        }

        public IEnumerable<AddOnInfo> Result { get; set; }

        protected override void RunTool()
        {
            var tool = new Apprenda.ACS.GetAddOns.GetAddOns(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            this.Result = tool.Execute(this.Settings);
        }
    }
}