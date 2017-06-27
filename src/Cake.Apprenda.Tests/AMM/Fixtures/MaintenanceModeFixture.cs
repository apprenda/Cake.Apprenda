using Cake.Apprenda.AMM;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Testing.Fixtures;
using NSubstitute;
// ReSharper disable InconsistentNaming

namespace Cake.Apprenda.Tests.AMM.Fixtures
{
    public abstract class MaintenanceModeFixture<TSettings> : MaintenanceModeFixture<TSettings, ToolFixtureResult>
        where TSettings : ToolSettings, new()
    {
        protected override ToolFixtureResult CreateResult(FilePath path, ProcessSettings process)
        {
            return new ToolFixtureResult(path, process);
        }
    }

    public abstract class MaintenanceModeFixture<TSettings, TFixtureResult> : ToolFixture<TSettings, TFixtureResult>
        where TSettings : ToolSettings, new()
        where TFixtureResult : ToolFixtureResult
    {
        public IMaintenanceModeToolResolver Resolver { get; set; }
        public ICakeLog Log { get; set; }

        protected MaintenanceModeFixture()
            : base("amm.exe")
        {
            Resolver = Substitute.For<IMaintenanceModeToolResolver>();
            Log = Substitute.For<ICakeLog>();
        }
    }
}
