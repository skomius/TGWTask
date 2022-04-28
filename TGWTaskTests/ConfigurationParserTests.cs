using Newtonsoft.Json;
using NSubstitute;
using System;
using System.IO;
using TGWTask.Domain;
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

            var rawConfigurationProvider = Substitute.For<IRawConfigurationProvider>();
            rawConfigurationProvider.GetRawConfiguration("Base_Config.txt").Returns(File.ReadAllText("Base_Config.txt"));

            var configurationParser = new ConfigurationParser(rawConfigurationProvider);
            var config = configurationParser.Parser("Base_Config.txt");

            Assert.Equal(PowerSupply.normal, config.PowerSupply);
        }
    }
}
