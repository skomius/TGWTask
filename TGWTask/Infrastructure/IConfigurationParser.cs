using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGWTask.Domain;

namespace TGWTask.Infrastructure
{
    public interface IConfigurationParser
    {
        Configuration Parser(string rawconfig);
    }
}
