using System;
using System.Configuration;

namespace Config.Provider
{
    public class ConfigurationProvider
    {
        private readonly Configuration _config;

        public ConfigurationProvider(string appConfigPath)
        {
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = appConfigPath };
            _config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);    
            
        }

        public TSection Read<TSection>(string sectionName) where TSection : ConfigurationSection
        {
            TSection section = _config.GetSection(sectionName) as TSection;
            if (section == null)
                throw new Exception(string.Format("config section {0} is missing", typeof(TSection).Name));

            return section;
        }
      
    }


    
}