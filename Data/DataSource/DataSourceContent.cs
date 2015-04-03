using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneRSS.Data.DataSource
{
    public class DataSourceContent<T> where T : class
    {
        public DateTime TimeStamp { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
