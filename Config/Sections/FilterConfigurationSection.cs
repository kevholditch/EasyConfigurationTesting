using System.Configuration;

namespace Config.Sections
{
    public class FilterConfigurationSection : ConfigurationSection
    {
        public const string SectionName = "customFilter";

        [ConfigurationProperty(FilterRangeElement.ElementName, IsRequired = true)]
        public virtual FilterRangeElement Range
        {
            get { return (FilterRangeElement)this[FilterRangeElement.ElementName]; }
            set { this[FilterRangeElement.ElementName] = value; }
        }

        public static FilterConfigurationSection GetSection()
        {
            return ConfigurationManager.GetSection(SectionName) as FilterConfigurationSection;
        }

    }
}