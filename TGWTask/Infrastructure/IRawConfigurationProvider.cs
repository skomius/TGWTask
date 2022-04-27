using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGWTask.Infrastructure
{
    public interface IRawConfigurationProvider
    {
        string GetRawConfiguration(string path);
    }
}
