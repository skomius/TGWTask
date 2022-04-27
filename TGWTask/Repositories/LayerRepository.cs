using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGWTask.Business;

namespace TGWTask.Repositories
{
    public class LayerRepository: ILayerRepository
    {
        private List<Layer> _layers;

        public LayerRepository()
        {
            _layers = new List<Layer>();
        }

        public Layer AddLayer(Layer layer)
        {
            _layers.Add(layer);
            return layer;
        }

        public Layer GetLayer(Guid guid)
        {
            return _layers.FirstOrDefault(x => x.Id == guid);
        }

        public IEnumerable<Layer> GetLayers()
        {
            return _layers;
        }
    }
}
