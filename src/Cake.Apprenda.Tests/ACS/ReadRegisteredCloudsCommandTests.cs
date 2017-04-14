using System.Linq;
using Cake.Apprenda;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS
{
    //public sealed class ReadRegisteredCloudsCommandTests
    //{
    //    [Fact]
    //    public void CommandNameShouldBeCorrect()
    //    {
    //        new ReadRegisteredCloudsCommand().CommandName.Should().Be("ReadRegisteredClouds");
    //    }

    //    [Fact]
    //    public void ParseResultsShouldSkipFirstLine()
    //    {
    //        var commmand = new ReadRegisteredCloudsCommand();
    //        var result = commmand.ParseResults(new[] { "\tFakeAlias\thttp://apps.apprenda.host" }).ToList();

    //        result.Should().HaveCount(0, "because the first line is a header line reading 'Registered Clouds'");
    //    }

    //    [Fact]
    //    public void ParseResultsShouldReturnCorrectResults()
    //    {
    //        var commmand = new ReadRegisteredCloudsCommand();
    //        var result = commmand.ParseResults(new[] { "Registered Clouds", "\tFakeAlias\thttp://apps.apprenda.host" }).ToList();

    //        result.Should().HaveCount(1);
    //        result.ElementAt(0).Alias.Should().Be("FakeAlias");
    //        result.ElementAt(0).Url.Should().Be("http://apps.apprenda.host");
    //    }
    //}
}
