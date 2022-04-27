using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGWTask.Business
{
    public class Configuration
    {
        public int? OrdersPerHour { get; set; }

        public int? OrderLinesPerOrder { get; set; }

        public InboundStrategy? InboundStrategy { get; set; }

        public PowerSupply? PowerSupply { get; set; }

        public TimeSpan? ResultStartTime { get; set; }

        public int? ResultInterval { get; set; }
     }
}
