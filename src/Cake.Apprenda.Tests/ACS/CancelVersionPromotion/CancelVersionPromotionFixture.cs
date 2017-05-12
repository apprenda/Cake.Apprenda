using Cake.Apprenda.ACS.CancelVersionPromotion;
using Cake.Apprenda.Tests.ACS.Fixtures;

namespace Cake.Apprenda.Tests.ACS.CancelVersionPromotion
{
    public sealed class CancelVersionPromotionFixture : CloudShellFixture<CancelVersionPromotionSettings>
    {
        public CancelVersionPromotionFixture()
        {
            this.Settings.VersionAlias = "v1";
            this.Settings.AppAlias = "someAppAlias";
        }

        protected override void RunTool()
        {
            var tool = new Apprenda.ACS.CancelVersionPromotion.CancelVersionPromotion(FileSystem, Environment, ProcessRunner, Tools, Resolver);
            tool.Execute(Settings);
        }
    }
}
