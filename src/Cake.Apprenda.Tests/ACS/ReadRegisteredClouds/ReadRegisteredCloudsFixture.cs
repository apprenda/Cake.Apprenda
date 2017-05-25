using System.Collections.Generic;
using Cake.Apprenda.ACS.ReadRegisteredClouds;
using Cake.Apprenda.Tests.ACS.Fixtures;

namespace Cake.Apprenda.Tests.ACS.ReadRegisteredClouds
{
    public sealed class ReadRegisteredCloudsFixture : CloudShellFixture<ReadRegisteredCloudsSettings>
    {
        public IEnumerable<CloudInfo> Result { get; set; }

        protected override void RunTool()
        {
            var tool = new Apprenda.ACS.ReadRegisteredClouds.ReadRegisteredClouds(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            this.Result = tool.Execute(this.Settings);
        }
    }
}