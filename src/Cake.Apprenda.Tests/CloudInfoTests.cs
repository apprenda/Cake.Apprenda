using Xunit;

namespace Cake.Apprenda.Tests
{
    public sealed class CloudInfoTests
    {
        public sealed class TheCtor
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public void Should_Throw_On_Null_Or_Empty_Alias(string alias)
            {
                // Given, When
                var ex = Record.Exception(() => new CloudInfo(alias, "url"));

                // Then
                Assert.IsArgumentException(ex, "cloudAlias", "Value cannot be null or empty.");
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public void Should_Throw_On_Null_Or_Empty_Url(string url)
            {
                // Given, When
                var ex = Record.Exception(() => new CloudInfo("alias", url));

                // Then
                Assert.IsArgumentException(ex, "cloudUrl", "Value cannot be null or empty.");
            }
        }
    }
}
