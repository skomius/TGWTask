using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGWTask.Business
{
    public class LayerFactory : ILayerFactory
    {
        public Layer Create(Configuration configuration, int level, LayerType layerType)
        {
            //validations, checks and other business logic   

            return new Layer
            {
                Id = Guid.NewGuid(),
                Configuration = configuration,
                Level = level,
                Type = layerType,
                Created = DateTime.UtcNow
            };
        }
    }
}
