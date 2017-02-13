using System;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests
{
    public sealed class ApplicationStageTests
    {
        [Fact]
        public void MembersMustBeNamedValidNames()
        {
            // this is because of the enum-string conversions that ACS has to understand.
            Enum.GetNames(typeof(ApplicationStage)).Should().HaveCount(3).And.ContainInOrder("Definition", "Sandbox", "Published");
        }
    }
}
