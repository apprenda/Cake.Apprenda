using System.Collections.Generic;
using Cake.Apprenda.AMM.ReadRegisteredClouds;
using Cake.Apprenda.Tests.AMM.Fixtures;

namespace Cake.Apprenda.Tests.AMM.ReadRegisteredClouds
{
    public sealed class ReadRegisteredCloudsFixture : MaintenanceModeFixture<ReadRegisteredCloudsSettings>
    {
        public IEnumerable<CloudInfo> Result { get; set; }

        protected override void RunTool()
        {
            var tool = new Apprenda.AMM.ReadRegisteredClouds.ReadRegisteredClouds(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            this.Result = tool.Execute(this.Settings);
        }
    }
}