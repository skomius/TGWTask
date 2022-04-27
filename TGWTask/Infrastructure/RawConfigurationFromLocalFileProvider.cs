using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGWTask.Infrastructure
{
    public class RawConfigurationFromLocalFileProvider: IRawConfigurationProvider
    {
        public string GetRawConfiguration(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
