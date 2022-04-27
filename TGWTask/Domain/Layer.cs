using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGWTask.Domain
{
    public class Layer
    {
        public Guid Id { get; set; }

        public LayerType Type { get; set; }

        public int Level { get; set; }

        public Configuration Configuration { get; set; }

        public DateTime Created { get; set; }
    }
}
