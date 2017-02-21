﻿using System;
using Cake.Apprenda.ACS.NewPackage;
using Cake.Core.IO;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.NewPackage
{
    public sealed class NewPackageSettingsTests : ACSSettingsTestsBase<NewPackageSettings>
    {
        [Theory]
        [InlineData(null)]
        public void TheCtorShouldThrowWhenSolutionFileIsNull(FilePath path)
        {
            Constructor(() => new NewPackageSettings(path, "./path/Archive.zip")).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("solutionPath");
        }

        [Theory]
        [InlineData(null)]
        public void TheCtorShouldThrowWhenArchiveFileIsNull(FilePath path)
        {
            Constructor(() => new NewPackageSettings("./path/Solution.sln", path)).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("archiveOutput");
        }

        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            Constructor(() => new NewPackageSettings("./path/Solution.sln", "./path/Archive.zip")).ShouldNotThrow();
        }
    }
}
