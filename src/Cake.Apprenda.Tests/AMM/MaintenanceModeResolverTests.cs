using System;
using Cake.Apprenda.Tests.AMM.Fixtures;
using Cake.Core;
using Cake.Testing;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.AMM
{
    public sealed class MaintenanceModeResolverTests
    {
        public sealed class TheConstructor
        {
            [Fact]
            public void Should_Throw_If_File_System_Is_Null()
            {
                // Given
                var fixture = new MaintenanceModeToolResolverFixture { FileSystem = null };

                // When
                var result = Record.Exception(() => fixture.Resolve());

                // Then
                result.Should().BeOfType<ArgumentNullException>().Which.ParamName.Should().Be("fileSystem");
            }

            [Fact]
            public void Should_Throw_If_Environment_Is_Null()
            {
                // Given
                var fixture = new MaintenanceModeToolResolverFixture { Environment = null };

                // When
                var result = Record.Exception(() => fixture.Resolve());

                // Then
                result.Should().BeOfType<ArgumentNullException>().Which.ParamName.Should().Be("environment");
            }

            [Fact]
            public void Should_Throw_If_Tool_Locator_Is_Null()
            {
                // Given
                var fixture = new MaintenanceModeToolResolverFixture { Tools = null };

                // When
                var result = Record.Exception(() => fixture.Resolve());

                // Then
                result.Should().BeOfType<ArgumentNullException>().Which.ParamName.Should().Be("tools");
            }
        }

        public sealed class TheResolveToolPathMethod
        {
            [Fact]
            public void Should_Throw_If_ACS_Exe_Could_Not_Be_Found()
            {
                // Given
                var fixture = new MaintenanceModeToolResolverFixture();

                // When
                var result = Record.Exception(() => fixture.Resolve());

                // Assert
                result.Should().BeOfType<CakeException>().Which.Message.Should().Be("Could not locate amm.exe.");
            }

            [Fact]
            public void Should_Be_Able_To_Resolve_Path_From_The_Tools_Directory()
            {
                // Given
                var fixture = new MaintenanceModeToolResolverFixture();
                fixture.FileSystem.CreateFile("/Working/tools/amm.exe");

                // When
                var result = fixture.Resolve();

                // Then
                Assert.Equal("/Working/tools/amm.exe", result.FullPath);
            }

            [Fact]
            public void Should_Be_Able_To_Resolve_Path_Via_Environment_Path_Variable_On_Unix()
            {
                // Given
                var fixture = new MaintenanceModeToolResolverFixture();
                fixture.Environment.SetEnvironmentVariable("PATH", "/temp:/stuff/programs:/programs");
                fixture.FileSystem.CreateFile("/stuff/programs/amm.exe");

                // When
                var result = fixture.Resolve();

                // Then
                Assert.Equal("/stuff/programs/amm.exe", result.FullPath);
            }

            [Fact]
            public void Should_Be_Able_To_Resolve_Path_Via_Environment_Path_Variable_On_Windows()
            {
                // Given
                var fixture = new MaintenanceModeToolResolverFixture(FakeEnvironment.CreateWindowsEnvironment());
                fixture.Environment.SetEnvironmentVariable("PATH", "/temp;/stuff/programs;/programs");
                fixture.FileSystem.CreateFile("/stuff/programs/amm.exe");

                // When
                var result = fixture.Resolve();

                // Then
                Assert.Equal("/stuff/programs/amm.exe", result.FullPath);
            }

            [Fact]
            public void Should_Be_Able_To_Resolve_Path_Via_ApprendaAMMInstall_Environment_Variable()
            {
                // Given
                var fixture = new MaintenanceModeToolResolverFixture();
                fixture.Environment.SetEnvironmentVariable("ApprendaAMMInstall", "/programs");
                fixture.FileSystem.CreateFile("/programs/amm.exe");

                // When
                var result = fixture.Resolve();

                // Then
                Assert.Equal("/programs/amm.exe", result.FullPath);
            }
        }
    }
}
