using Cake.Apprenda.ACS.CancelVersionPromotion;
using Xunit;
// ReSharper disable UseObjectOrCollectionInitializer

namespace Cake.Apprenda.Tests.ACS.CancelVersionPromotion
{
    public class CancelVersionPromotionTests : CloudShellCommandTestBase<Apprenda.ACS.CancelVersionPromotion.CancelVersionPromotion, CancelVersionPromotionSettings, CancelVersionPromotionFixture>
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new CancelVersionPromotionFixture { Settings = null };

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsArgumentNullException(result, "settings");
        }

        [Fact]
        public void Should_Throw_If_AppAlias_Is_Null()
        {
            // Given
            var fixture = new CancelVersionPromotionFixture();
            fixture.Settings.AppAlias = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting AppAlias not specified.");
        }

        [Fact]
        public void Should_Throw_If_VersionAlias_Is_Null()
        {
            // Given
            var fixture = new CancelVersionPromotionFixture();
            fixture.Settings.VersionAlias = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsCakeException(result, "Required setting VersionAlias not specified.");
        }

        [Fact]
        public void Should_Format_Arguments_Correctly()
        {
            // Given
            var fixture = new CancelVersionPromotionFixture();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("CancelVersionPromotion --NonInteractive -Y -AppAlias \"someAppAlias\" -VersionAlias v1", result.Args);
        }
    }
}
