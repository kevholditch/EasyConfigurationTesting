using System.Configuration;

namespace Config.Sections
{
    public class FilterRangeElement : ConfigurationElement
    {
        public const string ElementName = "range";

        [ConfigurationProperty("min", IsRequired = false, DefaultValue = int.MinValue)]
        public int Min
        {
            get { return (int)this["min"]; }
            set { this["min"] = value; }
        }

        [ConfigurationProperty("max", IsRequired = false, DefaultValue = 100)]
        public int Max
        {
            get { return (int)this["max"]; }
            set { this["max"] = value; }
        }
    }


}