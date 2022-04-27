using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGWTask.Domain;

namespace TGWTask.Repositories
{
    public interface ILayerRepository
    {
        Layer AddLayer(Layer layer);
        Layer GetLayer(Guid guid);
        IEnumerable<Layer> GetLayers();
    }
}
