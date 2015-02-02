using System.Collections.Generic;
using System.Threading;
using System.Web.Http;
using WebApp1.Models;

namespace WebApp1.Api
{
    public class NewsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<NewsItem> Get()
        {
            Thread.Sleep(3000);
            return new[] { 
                new NewsItem {Id = 1, Description = "Swetugg rocks!!!"}, 
                new NewsItem {Id = 2, Description = "Stockholm is the greatest city in sweden!" }
            };
        }

    }
}