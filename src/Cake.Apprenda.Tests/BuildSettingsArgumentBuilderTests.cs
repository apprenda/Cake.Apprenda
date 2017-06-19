using Cake.Apprenda.ACS;
using Cake.Core.IO;
using Xunit;

namespace Cake.Apprenda.Tests
{
    public sealed class BuildSettingsArgumentBuilderTests
    {
        [Fact]
        public void Should_Throw_When_Settings_Are_Null()
        {
            // Given, When
            var result = Record.Exception(() => new BuildSettingsArgumentBuilder().Build(null, new ProcessArgumentBuilder()));

            // Then
            Assert.IsArgumentNullException(result, "settings");
        }

        [Fact]
        public void Should_Throw_When_ArgumentBuilder_Is_Null()
        {
            // Given, When
            var result = Record.Exception(() => new BuildSettingsArgumentBuilder().Build(new BuildSettings(), null));

            // Then
            Assert.IsArgumentNullException(result, "builder");
        }

        [Fact]
        public void Should_Format_Arguments_Correctly()
        {
            // Given
            var builder = new ProcessArgumentBuilder();
            var settings = new BuildSettings
            {
                Configuration = "Release",
                IgnoreFilters = new[] { "*.h", "*.suo" },
                RebuildSolution = true,
                StoredProcedureProjects = new[] { "SPP", "SPP2" },
                UserInterfaceProjects = new[] { "UI1", "UI2" },
                UserInterfaceRoot = "UI1",
                WcfProjects = new[] { "WCF1", "WCF2" },
                WindowsServiceProjects = new[] { "WSP1", "WSP2" }
            };

            // When
            new BuildSettingsArgumentBuilder().Build(settings, builder);

            // Then
            Assert.Equal("-B -Config \"Release\" -Filters \"*.h *.suo\" -S \"WCF1 WCF2\" -WS \"WSP1 WSP2\" -StoredProcs \"SPP SPP2\" -I \"UI1 UI2\" -PrivateRoot \"UI1\"", builder.Render());
        }
    }
}
