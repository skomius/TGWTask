using Newtonsoft.Json;
using System;
using System.IO;
using TGWTask.Business;
using TGWTask.Infrastructure;
using Xunit;

namespace TGWTaskTests
{
    public class ConfigurationParserTests
    {
        [Fact]
        public void ConfigurationParser_ShouldReturnParsedProperties()
        {
            var rawConfig = File.ReadAllText("Base_Config.txt");

            var configurationParser = new ConfigurationParser();
            var configProperties = configurationParser.Parser(rawConfig);

            var serialize = JsonConvert.SerializeObject(configProperties);
            var configuration = JsonConvert.DeserializeObject<Configuration>(serialize);

            Assert.Equal(6, configProperties.Count);
            Assert.Equal("normal", configProperties["powerSupply"]);
        }
    }
}
