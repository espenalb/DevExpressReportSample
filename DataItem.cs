using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpressReportSample
{
    public class DataItem
    {
        static int counter;
        public string Name { get; set; } = $"Name{counter++}";
        public string Description { get; set; } = $"Description{counter++}";
    }

    public class DataSource
    {
        public List<DataItem> Data { get; set; } = CreateData(100);

        private static List<DataItem> CreateData(int v)
        {
            return Enumerable.Range(0, v).Select(x => new DataItem()).ToList();
        }
    }
}
