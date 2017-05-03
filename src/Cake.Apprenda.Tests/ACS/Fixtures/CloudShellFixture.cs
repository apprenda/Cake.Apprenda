using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Testing.Fixtures;
using NSubstitute;
// ReSharper disable InconsistentNaming

namespace Cake.Apprenda.Tests.ACS.Fixtures
{
    public abstract class CloudShellFixture<TSettings> : CloudShellFixture<TSettings, ToolFixtureResult>
        where TSettings : ToolSettings, new()
    {
        protected override ToolFixtureResult CreateResult(FilePath path, ProcessSettings process)
        {
            return new ToolFixtureResult(path, process);
        }
    }

    public abstract class CloudShellFixture<TSettings, TFixtureResult> : ToolFixture<TSettings, TFixtureResult>
        where TSettings : ToolSettings, new()
        where TFixtureResult : ToolFixtureResult
    {
        public ICloudShellToolResolver Resolver { get; set; }
        public ICakeLog Log { get; set; }

        protected CloudShellFixture()
            : base("acs.exe")
        {
            Resolver = Substitute.For<ICloudShellToolResolver>();
            Log = Substitute.For<ICakeLog>();
        }
    }
}
