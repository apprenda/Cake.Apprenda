using System;
using Cake.Apprenda.ACS.SetInstanceCount;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.SetInstanceCount
{
    public sealed class ScalingExpressionTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("\t")]
        [InlineData("\r\n")]
        public void TheCtorShouldThrowOnNullOrWhitespace(string value)
        {
            // ReSharper disable once NotAccessedVariable
            ScalingExpression expr;
            Action action = ()=> expr = new ScalingExpression(value);

            action.ShouldThrow<ArgumentException>();
        }

        [Theory]
        [InlineData("+1")]
        [InlineData("-1")]
        [InlineData("0")]
        [InlineData("1")]
        [InlineData("asdf")]
        public void TheValuePropertyShouldReturnCorrectValue(string verbatim)
        {
            var expr = new ScalingExpression(verbatim);
            expr.Value.Should().Be(verbatim);
        }

        [Theory]
        [InlineData("+1")]
        [InlineData("-1")]
        [InlineData("0")]
        [InlineData("1")]
        [InlineData("asdf")]
        public void TheToStringMethodShouldReturnValue(string verbatim)
        {
            var expr = new ScalingExpression(verbatim);
            expr.ToString().Should().Be(verbatim);
        }
    }
}