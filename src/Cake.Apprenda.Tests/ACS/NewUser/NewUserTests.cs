using System.Linq;
using Cake.Apprenda.ACS.NewUser;
using Xunit;
// ReSharper disable UseObjectOrCollectionInitializer

namespace Cake.Apprenda.Tests.ACS.NewUser
{
    public sealed class NewUserTests : CloudShellCommandTestBase<Apprenda.ACS.NewUser.NewUser, NewUserSettings, NewUserFixture>
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new NewUserFixture { Settings = null };

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsArgumentNullException(result, "settings");
        }

        [Fact]
        public void Should_Throw_If_EmailAddress_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new NewUserFixture();
            fixture.Settings.EmailAddress = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting EmailAddress not specified.");
        }

        [Fact]
        public void Should_Throw_If_FirstName_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new NewUserFixture();
            fixture.Settings.FirstName = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting FirstName not specified.");
        }

        [Fact]
        public void Should_Throw_If_LastName_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new NewUserFixture();
            fixture.Settings.LastName = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting LastName not specified.");
        }

        [Fact]
        public void Should_Throw_If_Password_Is_Null_Or_Empty()
        {
            // Given
            var fixture = new NewUserFixture();
            fixture.Settings.Password = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting Password not specified.");
        }

        [Theory]
        [InlineData(null, "")]
        [InlineData("admin,superadmin", " -Roles admin,superadmin")]
        public void Should_Format_Arguments_Correctly(string roles, string expected)
        {
            // Given
            var fixture = new NewUserFixture();
            fixture.Settings.Roles = roles?.Split(',').ToList();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal($"NewUser --NonInteractive -EmailAddress user@apprenda.com -FirstName Fake -LastName User -Password p@ssword{expected}", result.Args);
        }
    }
}
