using Microsoft.Extensions.Configuration;

namespace Automation.Shared.Config
{
    public static class ConfigurationManager
    {
        public static IConfiguration AppSetting { get; }
        static ConfigurationManager()
        {
            AppSetting = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("testConfig.json")
                    .Build();
        }
    }
}
