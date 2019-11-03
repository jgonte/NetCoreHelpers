using Microsoft.Extensions.Configuration;
using System.IO;

namespace NetCoreHelpers
{
    public static class ConfigurationHelper
    {
        public static IConfigurationRoot GetConfiguration(string path = null, string environmentName = null, bool addUserSecrets = false)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                path = Directory.GetCurrentDirectory();
            }

            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            if (!string.IsNullOrWhiteSpace(environmentName))
            {
                builder = builder.AddJsonFile($"appsettings.{environmentName}.json", optional: true);
            }

            //builder = builder.AddEnvironmentVariables();

            if (addUserSecrets)
            {
                //builder.AddUserSecrets();
            }

            return builder.Build();
        }
    }
}
