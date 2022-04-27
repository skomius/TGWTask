using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGWTask.Domain;

namespace TGWTask.Application
{
    public interface ILayerService
    {
        Layer AddLayer(int level, string ConfigurationPath, LayerType layerType);
    }
}
