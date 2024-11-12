using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NkosisHavenAppApi.Common
{
    public class AppSettings
    {
        public IEnumerable<string> AllowedOrigins { get; set; }
        public ConnectionStrings? ConnectionStrings { get; set; }
        public string FilePath { get; set; }
    }

    public class ConnectionStrings
    {
        public string? DbConnection { get; set; }
    }
}
