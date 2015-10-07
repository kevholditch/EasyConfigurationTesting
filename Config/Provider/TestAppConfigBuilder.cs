using System.Configuration;
using System.IO;

namespace Config.Provider
{
    public class TestAppConfigBuilder
    {
        private readonly string _appConfig;

        public TestAppConfigBuilder(string appConfig)
        {
            _appConfig = appConfig;            

        }

        public static implicit operator TestAppConfigContext(TestAppConfigBuilder testAppConfigBuilder)
        {
            return testAppConfigBuilder.Build();
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