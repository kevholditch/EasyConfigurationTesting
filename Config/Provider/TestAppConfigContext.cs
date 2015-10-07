using System.IO;

namespace Config.Provider
{
    public class TestAppConfigContext
    {
        public TestAppConfigContext(string configFilePath)
        {
            ConfigFilePath = configFilePath;
        }

        public string ConfigFilePath { get; private set; }

        public void Destroy()
        {
            if (File.Exists(ConfigFilePath))
                File.Delete(ConfigFilePath);
        }
    }
}