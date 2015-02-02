using System.Collections.Generic;
using System.Diagnostics;

namespace WebApp1.Models
{
    public class HomeViewModel
    {
        readonly Stopwatch _sw = new Stopwatch();

        public HomeViewModel()
        {
            _sw.Start();
        }

        public string Message { get; set; }

        public NewsItem[] News { get; set; }

        public IEnumerable<Product> Products { get; set; }

        public long ElapsedTime { get { return _sw.ElapsedMilliseconds; }}
    }
}
