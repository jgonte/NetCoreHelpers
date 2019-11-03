using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace NetCoreHelpers.Tests
{
    [TestClass]
    public class ConfigurationHelperTests
    {
        [TestMethod]
        public void TestConfigurationHelper()
        {
            var configuration = ConfigurationHelper.GetConfiguration();

            var section = configuration.GetSection("connections");

            Assert.IsTrue(section.Exists());

            Assert.AreEqual("connections", section.Key);

            var connections = section.GetChildren().ToArray();

            Assert.AreEqual(2, connections.Count());

            var connection = connections.First();

            Assert.AreEqual("Name1", connection.Key);

            var connectionString = connection.GetChildren().Single(ch => ch.Key == "connectionString").Value;

            Assert.AreEqual("ConnectionString1", connectionString);

            var providerName = connection.GetChildren().Single(ch => ch.Key == "providerName").Value;

            Assert.AreEqual("ProviderName1", providerName);

            connection = connections.Last();

            Assert.AreEqual("Name2", connection.Key);

            connectionString = connection.GetChildren().Single(ch => ch.Key == "connectionString").Value;

            Assert.AreEqual("ConnectionString2", connectionString);

            providerName = connection.GetChildren().Single(ch => ch.Key == "providerName").Value;

            Assert.AreEqual("ProviderName2", providerName);
        }
    }
}
