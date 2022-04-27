using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGWTask.Application
{
    public interface IConfigurationPropertyService
    {
        string GetConfigurationProperty(string propertyName);
    }
}
