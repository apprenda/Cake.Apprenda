using Cake.Apprenda.AMM;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Testing;

namespace Cake.Apprenda.Tests.AMM.Fixtures
{
    internal sealed class MaintenanceModeToolResolverFixture
    {
        public FakeFileSystem FileSystem { get; set; }
        public FakeEnvironment Environment { get; set; }
        public ToolLocator Tools { get; set; }

        public MaintenanceModeToolResolverFixture(FakeEnvironment environment = null)
        {
            this.Environment = environment ?? FakeEnvironment.CreateUnixEnvironment();
            this.FileSystem = new FakeFileSystem(this.Environment);
            this.Tools = new ToolLocator(
                this.Environment,
                new ToolRepository(this.Environment),
                new ToolResolutionStrategy(this.FileSystem, this.Environment, new Globber(this.FileSystem, this.Environment), new FakeConfiguration()));
        }

        public FilePath Resolve()
        {
            var resolver = new MaintenanceModeToolResolver(this.FileSystem, this.Environment, this.Tools);
            return resolver.ResolvePath();
        }
    }
}
