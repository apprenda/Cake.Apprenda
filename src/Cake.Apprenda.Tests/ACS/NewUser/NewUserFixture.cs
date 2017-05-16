using Cake.Apprenda.ACS.NewUser;
using Cake.Apprenda.Tests.ACS.Fixtures;

namespace Cake.Apprenda.Tests.ACS.NewUser
{
    public sealed class NewUserFixture : CloudShellFixture<NewUserSettings>
    {
        public NewUserFixture()
        {
            this.Settings.EmailAddress = "user@apprenda.com";
            this.Settings.FirstName = "Fake";
            this.Settings.LastName = "User";
            this.Settings.Password = "p@ssword";
        }

        protected override void RunTool()
        {
            var tool = new Apprenda.ACS.NewUser.NewUser(this.FileSystem, this.Environment, this.ProcessRunner, this.Tools, this.Resolver);
            tool.Execute(this.Settings);
        }
    }
}