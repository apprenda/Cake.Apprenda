using System;
using Cake.Apprenda.ACS.ExportArchive;
using Cake.Core.IO;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.ExportArchive
{
    public sealed class ExportArchiveSettingsTests : ACSSettingsTestsBase<ExportArchiveSettings>
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenAppAliasIsNullOrEmpty(string appAlias)
        {
            Constructor(() => new ExportArchiveSettings(appAlias, "versionAlias", "./path/file.zip")).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("appAlias");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenVersionAliasIsNullOrEmpty(string versionAlias)
        {
            Constructor(() => new ExportArchiveSettings("appAlias", versionAlias, "./path/file.zip")).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("versionAlias");
        }

        [Theory]
        [InlineData(null)]
        public void TheCtorShouldThrowWhenArchiveFileIsNull(FilePath path)
        {
            Constructor(() => new ExportArchiveSettings("appAlias", "versionAlias", path)).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("archiveFile");
        }

        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            Constructor(() => new ExportArchiveSettings("appAlias", "versionAlias", "./path/file.zip")).ShouldNotThrow();
        }
    }
}
