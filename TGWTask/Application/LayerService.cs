using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGWTask.Business;
using TGWTask.Infrastructure;
using TGWTask.Repositories;

namespace TGWTask.Application
{
    public class LayerService: ILayerService
    {
        private readonly ILayerRepository _layerRepository;
        private readonly IConfigurationParser _configurationParser;
        private readonly ILayerFactory _layerFactory;

        public LayerService( ILayerRepository layerRepository, IConfigurationParser configurationParser, ILayerFactory layerFactory)
        {
            _layerRepository = layerRepository ?? throw new NullReferenceException(nameof(layerRepository));
            _configurationParser = configurationParser ?? throw new NullReferenceException(nameof(configurationParser));
            _layerFactory = layerFactory ?? throw new NullReferenceException(nameof(layerFactory));
        }

        public Layer AddLayer(int level, string ConfigurationPath, LayerType layerType)
        {
            var configuration = _configurationParser.Parser(ConfigurationPath);

            var layer = _layerFactory.Create(configuration, level, layerType);

            return _layerRepository.AddLayer(layer);        
        } 
    }
}
