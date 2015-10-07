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
        public void ShardFilterReadsTheRange()
        {
            var testContext = BuildA.TestAppConfig.WithAppConfig(@"<?xml version=""1.0""?>
            <configuration>
              <configSections>
                <section name=""customFilter"" type=""Config.Sections.FilterConfigurationSection, Config""/>
              </configSections>
              <customFilter>
                <range min=""1"" max=""500"" />
              </customFilter>
            </configuration>").Build();


            var shardFilterConfigurationProvider = new ConfigurationProvider(testContext.ConfigFilePath);
            var shardFilterConfig = shardFilterConfigurationProvider.Read<FilterConfigurationSection>(FilterConfigurationSection.SectionName);

            shardFilterConfig.Range.Min.Should().Be(1);
            shardFilterConfig.Range.Max.Should().Be(500);            

            testContext.Destroy();

        }
    }
}