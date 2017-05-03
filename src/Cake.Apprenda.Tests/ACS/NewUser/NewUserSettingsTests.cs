using System;
using Cake.Apprenda.ACS.NewUser;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.NewUser
{
    public sealed class NewUserSettingsTests : CloudShellSettingsTestsBase<NewUserSettings>
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenEmailAddressIsNullOrEmpty(string email)
        {
            Constructor(() => new NewUserSettings(email, "Bob", "Smith", "p@ssword")).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("emailAddress");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenFirstNameIsNullOrEmpty(string firstName)
        {
            Constructor(() => new NewUserSettings("foo@bar.com", firstName, "Smith", "p@ssword")).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("firstName");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenLastNameIsNullOrEmpty(string lastName)
        {
            Constructor(() => new NewUserSettings("foo@bar.com", "Bob", lastName, "p@ssword")).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("lastName");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenPasswordIsNullOrEmpty(string password)
        {
            Constructor(() => new NewUserSettings("foo@bar.com", "Bob", "Smith", password)).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("password");
        }

        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            Constructor(() => new NewUserSettings("foo@bar.com", "Bob", "Smith", "p@ssword")).ShouldNotThrow();
        }
    }
}
