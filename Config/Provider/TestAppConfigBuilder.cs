using System.Configuration;
using System.IO;

namespace Config.Provider
{
    public class TestAppConfigBuilder
    {
        private string _appConfig;

        public TestAppConfigBuilder WithAppConfig(string appConfig)
        {
            _appConfig = appConfig;
            return this;

        }

        public TestAppConfigContext Build()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();

            string tempPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

            File.WriteAllText(tempPath, _appConfig);

            fileMap.ExeConfigFilename = tempPath;

            return new TestAppConfigContext(tempPath);
        }
    }
}