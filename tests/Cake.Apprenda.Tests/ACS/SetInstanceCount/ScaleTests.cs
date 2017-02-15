using System;
using Cake.Apprenda.ACS.SetInstanceCount;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.SetInstanceCount
{
    public sealed class ScaleTests
    {
        public sealed class TheExactlyMethod
        {
            [Fact]
            public void ExpressionShouldBeBuiltCorrectly()
            {
                var expr = Scale.To(2);
                expr.Value.Should().Be("2");
            }
        }

        public sealed class TheUpMethod
        {
            [Fact]
            public void ExpressionShouldBeBuiltCorrectly()
            {
                var expr = Scale.Up(2);
                expr.Value.Should().Be("+2");
            }

            [Theory]
            [InlineData(0)]
            [InlineData(-1)]
            public void ShouldThrowArgumentOutOfRange(int count)
            {
                Action action = () => Scale.Up(count);
                action.ShouldThrow<ArgumentOutOfRangeException>("because a non-zero magnitude should be passed");
            }
        }

        public sealed class TheDownMethod
        {
            [Fact]
            public void ExpressionShouldBeBuiltCorrectly()
            {
                var expr = Scale.Down(2);
                expr.Value.Should().Be("-2");
            }

            [Theory]
            [InlineData(0)]
            [InlineData(-1)]
            public void ShouldThrowArgumentOutOfRange(int count)
            {
                Action action = () => Scale.Down(count);
                action.ShouldThrow<ArgumentOutOfRangeException>("because a non-zero magnitude should be passed");
            }
        }

        public sealed class TheByDeltaMethod
        {
            [Theory]
            [InlineData(-1, "-1")]
            [InlineData(1, "+1")]
            public void ExpressionShouldBeBuiltCorrectly(int delta, string expression)
            {
                var expr = Scale.ByDelta(delta);
                expr.Value.Should().Be(expression);
            }

            [Fact]
            public void ShouldThrowArgumentException()
            {
                Action action = () => Scale.ByDelta(0);
                action.ShouldThrow<ArgumentException>();
            }
        }
    }
}
