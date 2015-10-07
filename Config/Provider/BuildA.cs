namespace Config.Provider
{
    public static class BuildA
    {        
        public static TestAppConfigBuilder NewTestAppConfig(string config)
        {
            return new TestAppConfigBuilder(config);
        }
    }
}