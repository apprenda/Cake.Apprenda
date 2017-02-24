using System.Collections.Generic;
using System.Linq;
using Cake.Apprenda.ACS.GetDeployedAddOns;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.GetDeployedAddOns
{
    public sealed class DeployedAddOnParserTests
    {
        [Fact]
        public void NoAddOnsShouldParseCorrectly()
        {
            var strings = new[]
            {
                null,
                "No deployed add-ons found",
                null
            };

            var parser = new DeployedAddOnParser();

            IEnumerable<DeployedAddOnInfo> results = null;
            var ex = Record.Exception(() => results = parser.ParseResults(strings));

            ex.Should().BeNull();
            results.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void SingleAddOnShouldParseCorrectly()
        {
            var strings = new[]
            {
                null,
                "Deployed add-ons:",
                null,
                ":",
                "Alias: fshare",
                "Instance Alias: myinstance",
                "Author: ",
                "Vendor: ",
                "Connection Data: \\\\zethos\\AddOns\\devteam\\myinstance",
                "Deploy Time: 2/24/2017 9:35:27 PM",
            };

            var parser = new DeployedAddOnParser();

            List<DeployedAddOnInfo> results = null;
            var ex = Record.Exception(() => results = parser.ParseResults(strings).ToList());

            ex.Should().BeNull();
            results.Should().NotBeNull().And.HaveCount(1);

            var addon = results[0];
            addon.Alias.Should().Be("fshare");
            addon.InstanceAlias.Should().Be("myinstance");
            addon.Author.Should().Be("");
            addon.Vendor.Should().Be("");
            addon.ConnectionData.Should().Be("\\\\zethos\\AddOns\\devteam\\myinstance");
            addon.DeploymentTime.Should().Be("2/24/2017 9:35:27 PM");
        }

        [Fact]
        public void MultipleAddOnsShouldParseCorrectly()
        {
            var strings = new[]
            {
                null,
                "Deployed add-ons:",
                null,
                ":",
                "Alias: fshare",
                "Instance Alias: myinstance",
                "Author: ",
                "Vendor: ",
                "Connection Data: \\\\zethos\\AddOns\\devteam\\myinstance",
                "Deploy Time: 2/24/2017 9:35:27 PM",
                null,
                ":",
                "Alias: conn",
                "Instance Alias: conninstance",
                "Author: ",
                "Vendor: ",
                "Connection Data: foobar",
                "Deploy Time: 2/24/2017 10:04:36 PM",
            };

            var parser = new DeployedAddOnParser();

            List<DeployedAddOnInfo> results = null;
            var ex = Record.Exception(() => results = parser.ParseResults(strings).ToList());

            ex.Should().BeNull();
            results.Should().NotBeNull().And.HaveCount(2);

            var fshare = results[0];
            fshare.Alias.Should().Be("fshare");
            fshare.InstanceAlias.Should().Be("myinstance");
            fshare.Author.Should().Be("");
            fshare.Vendor.Should().Be("");
            fshare.ConnectionData.Should().Be("\\\\zethos\\AddOns\\devteam\\myinstance");
            fshare.DeploymentTime.Should().Be("2/24/2017 9:35:27 PM");

            var conn = results[1];
            conn.Alias.Should().Be("conn");
            conn.InstanceAlias.Should().Be("conninstance");
            conn.Author.Should().Be("");
            conn.Vendor.Should().Be("");
            conn.ConnectionData.Should().Be("foobar");
            conn.DeploymentTime.Should().Be("2/24/2017 10:04:36 PM");
        }
    }
}
