using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Testing.Fixtures;
using NSubstitute;
// ReSharper disable InconsistentNaming

namespace Cake.Apprenda.Tests.ACS.Fixtures
{
    internal abstract class ACSFixture<TSettings> : ACSFixture<TSettings, ToolFixtureResult>
        where TSettings : ToolSettings, new()
    {
        protected override ToolFixtureResult CreateResult(FilePath path, ProcessSettings process)
        {
            return new ToolFixtureResult(path, process);
        }
    }

    internal abstract class ACSFixture<TSettings, TFixtureResult> : ToolFixture<TSettings, TFixtureResult>
        where TSettings : ToolSettings, new()
        where TFixtureResult : ToolFixtureResult
    {
        public IACSToolResolver Resolver { get; set; }
        public ICakeLog Log { get; set; }

        protected ACSFixture()
            : base("acs.exe")
        {
            Resolver = Substitute.For<IACSToolResolver>();
            Log = Substitute.For<ICakeLog>();
        }
    }
}
