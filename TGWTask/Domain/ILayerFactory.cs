using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGWTask.Domain
{
    public interface ILayerFactory
    {
        Layer Create(Configuration configuration, int level, LayerType layerType);
    }
}
