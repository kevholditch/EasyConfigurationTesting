using Config.Provider;
using Config.Sections;
using FluentAssertions;
using NUnit.Framework;

namespace Config.Tests
{
    [TestFixture]
    public class CustomFilterSectionTests
    {
        [Test]
        public void CanReadRangeWhenMinAndMaxSet()
        {
            TestAppConfigContext testContext = BuildA.NewTestAppConfig(@"<?xml version=""1.0""?>
            <configuration>
              <configSections>
                <section name=""customFilter"" type=""Config.Sections.FilterConfigurationSection, Config""/>
              </configSections>
              <customFilter>
                <range min=""1"" max=""500"" />
              </customFilter>
            </configuration>");


            var configurationProvider = new ConfigurationProvider(testContext.ConfigFilePath);
            var filterConfigSection = configurationProvider.Read<FilterConfigurationSection>(FilterConfigurationSection.SectionName);

            filterConfigSection.Range.Min.Should().Be(1);
            filterConfigSection.Range.Max.Should().Be(500);            

            testContext.Destroy();

        }

        [Test]
        public void CanReadRangeWhenOnlyMinSet()
        {
            TestAppConfigContext testContext = BuildA.NewTestAppConfig(@"<?xml version=""1.0""?>
            <configuration>
              <configSections>
                <section name=""customFilter"" type=""Config.Sections.FilterConfigurationSection, Config""/>
              </configSections>
              <customFilter>
                <range min=""1"" />
              </customFilter>
            </configuration>");


            var configurationProvider = new ConfigurationProvider(testContext.ConfigFilePath);
            var filterConfigSection = configurationProvider.Read<FilterConfigurationSection>(FilterConfigurationSection.SectionName);

            filterConfigSection.Range.Min.Should().Be(1);
            filterConfigSection.Range.Max.Should().Be(100);

            testContext.Destroy();

        }
    }
}