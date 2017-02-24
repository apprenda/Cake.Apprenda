using System.Collections.Generic;
using System.Linq;
using Cake.Apprenda.ACS.GetAddOns;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.GetAddOns
{
    public sealed class AddOnParserTests
    {
        [Fact]
        public void NoAddOnsShouldParseCorrectly()
        {
            var strings = new string[]
            {
                null,
                "No add-ons found",
                null
            };

            var parser = new AddOnParser();

            IEnumerable<AddOnInfo> results = null;
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
                "Add-ons:",
                null,
                "MongoDB:",
                "Alias: mongo",
                "Author: Bob Smith",
                "Vendor: Apprenda",
                "Description: Provides MongoDB databases scoped to a development team.",
                "Allows Arbitrary Parameters: True",
                "Help: When deploying a new MongoDB database you need to specify the credentials you want to use in your app to connect to this database.These credentials should be passed in using the developerOptions argument in the following format: username =< username >,password =< password >"
            };

            var parser = new AddOnParser();

            List<AddOnInfo> results = null;
            var ex = Record.Exception(() => results = parser.ParseResults(strings).ToList());

            ex.Should().BeNull();
            results.Should().NotBeNull().And.HaveCount(1);

            var addon = results[0];
            addon.Name.Should().Be("MongoDB");
            addon.Alias.Should().Be("mongo");
            addon.Author.Should().Be("Bob Smith");
            addon.Vendor.Should().Be("Apprenda");
            addon.Description.Should().Be("Provides MongoDB databases scoped to a development team.");
            addon.AllowsArbitraryParameters.Should().BeTrue();
            addon.HelpText.Should().StartWith("When deploying a new MongoDB").And.EndWith("username =< username >,password =< password >");
        }

        [Fact]
        public void MultipleAddOnsShouldParseCorrectly()
        {
            var strings = new[]
            {
                null,
                "Add-ons:",
                null,
                "MongoDB:",
                "Alias: mongo",
                "Author: Bob Smith",
                "Vendor: Apprenda",
                "Description: Provides MongoDB databases scoped to a development team.",
                "Allows Arbitrary Parameters: True",
                "Help: When deploying a new MongoDB database you need to specify the credentials you want to use in your app to connect to this database.These credentials should be passed in using the developerOptions argument in the following format: username =< username >,password =< password >",
                null,
                "File Share:",
                "Alias: fshare",
                "Author: Bob Smith",
                "Vendor: Apprenda",
                "Description: Provides shared storage scoped to a development tenant within guest applications.",
                "Allows Arbitrary Parameters: False",
                "Help: Use the value '--testError' as the Options argument to tell the add-on to throw an unhandled exception.  Use the '--testUserError' option to test returning an error message to the user.",
            };

            var parser = new AddOnParser();

            List<AddOnInfo> results = null;
            var ex = Record.Exception(() => results = parser.ParseResults(strings).ToList());

            ex.Should().BeNull();
            results.Should().NotBeNull().And.HaveCount(2);

            var mongo = results[0];
            mongo.Name.Should().Be("MongoDB");
            mongo.Alias.Should().Be("mongo");
            mongo.Author.Should().Be("Bob Smith");
            mongo.Vendor.Should().Be("Apprenda");
            mongo.Description.Should().Be("Provides MongoDB databases scoped to a development team.");
            mongo.AllowsArbitraryParameters.Should().BeTrue();
            mongo.HelpText.Should().StartWith("When deploying a new MongoDB").And.EndWith("username =< username >,password =< password >");

            var fshare = results[1];
            fshare.Name.Should().Be("File Share");
            fshare.Alias.Should().Be("fshare");
            fshare.Author.Should().Be("Bob Smith");
            fshare.Vendor.Should().Be("Apprenda");
            fshare.Description.Should().Be("Provides shared storage scoped to a development tenant within guest applications.");
            fshare.AllowsArbitraryParameters.Should().BeFalse();
            fshare.HelpText.Should().StartWith("Use the value '--testError' as the Options").And.EndWith("Use the '--testUserError' option to test returning an error message to the user.");
        }
    }
}
