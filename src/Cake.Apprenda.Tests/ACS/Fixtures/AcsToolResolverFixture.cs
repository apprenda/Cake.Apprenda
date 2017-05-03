using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Testing;
// ReSharper disable InconsistentNaming

namespace Cake.Apprenda.Tests.ACS.Fixtures
{
    internal sealed class ACSToolResolverFixture
    {
        public FakeFileSystem FileSystem { get; set; }
        public FakeEnvironment Environment { get; set; }
        public ToolLocator Tools { get; set; }

        public ACSToolResolverFixture(FakeEnvironment environment = null)
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
            var resolver = new CloudShellToolResolver(this.FileSystem, this.Environment, this.Tools);
            return resolver.ResolvePath();
        }
    }
}
