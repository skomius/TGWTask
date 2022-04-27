using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TGWTask.Business;

namespace TGWTask.Infrastructure
{
    // can be made generic work with any configuration
    public class ConfigurationParser : IConfigurationParser
    {
        private readonly IRawConfigurationProvider _rawConfigurationProvider;

        public ConfigurationParser( IRawConfigurationProvider rawConfigurationProvider)
        {
            _rawConfigurationProvider = rawConfigurationProvider ?? throw new ArgumentNullException(nameof(rawConfigurationProvider));
        }

        public Configuration Parser(string path)
        {
            var rawConfig = _rawConfigurationProvider.GetRawConfiguration(path);

            IDictionary<string, string> properties = new Dictionary<string, string>();
            foreach (var line in rawConfig.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
            {

                var array = Regex.Split(line, ":\t+");
                if (array.Length == 2)
                {
                    var value = Regex.Split(array[1], "\\s");
                    properties.Add(array[0], value[0]);
                }
            }

            var serialize = JsonConvert.SerializeObject(properties);
            var configuration = JsonConvert.DeserializeObject<Configuration>(serialize);

            return configuration;
        }
    }
}
