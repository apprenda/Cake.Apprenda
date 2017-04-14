using System;
using Cake.Apprenda.ACS.ExportManifest;
using Cake.Core.IO;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.ExportManifest
{
    public sealed class ExportManifestSettingsTests : ACSSettingsTestsBase<ExportManifestSettings>
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenAppAliasIsNullOrEmpty(string appAlias)
        {
            Constructor(() => new ExportManifestSettings(appAlias, "versionAlias", "./path/file.zip")).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("appAlias");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenVersionAliasIsNullOrEmpty(string versionAlias)
        {
            Constructor(() => new ExportManifestSettings("appAlias", versionAlias, "./path/file.zip")).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("versionAlias");
        }

        [Theory]
        [InlineData(null)]
        public void TheCtorShouldThrowWhenArchiveFileIsNull(FilePath path)
        {
            Constructor(() => new ExportManifestSettings("appAlias", "versionAlias", path)).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("manifestFile");
        }

        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            Constructor(() => new ExportManifestSettings("appAlias", "versionAlias", "./path/file.zip")).ShouldNotThrow();
        }
    }
}
