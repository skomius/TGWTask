using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGWTask.Repositories;

namespace TGWTask.Application
{
    public class ConfigurationPropertyService: IConfigurationPropertyService
    {
        private readonly ILayerRepository _layerRepository;

        public ConfigurationPropertyService(ILayerRepository layerRepository)
        {
            _layerRepository = layerRepository ?? throw new NullReferenceException(nameof(layerRepository));
        }

        public string GetConfigurationProperty(string propertyName)
        {
          //:D gal kazkaip galima ir geriau
          var configurations = _layerRepository.GetLayers().Select(x => JsonConvert.DeserializeObject<IDictionary<string, string>>(JsonConvert.SerializeObject(x.Configuration)));
          return configurations.Select(x => x[propertyName]).LastOrDefault(x => x != null);
        }
    }
}
