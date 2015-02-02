using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using WebApp1.Models;
using WebApp1.Repositories;

namespace WebApp1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var model = new HomeViewModel();
            model.Message = "Your application description page.";

            var repo = new ProductRepository();

            var products = repo.GetAllProducts();
            var news = GetNewsItems();

            model.News = news;
            model.Products = products;

            return View(model);
        }

        private NewsItem[] GetNewsItems()
        {
            var client = new WebClient();
            var newsString = client.DownloadString("http://localhost/webapp1/api/news");
            var news = JsonConvert.DeserializeObject<NewsItem[]>(newsString);
            return news;
        }

        private async Task<NewsItem[]> GetNewsItemsAsync()
        {
            var client = new HttpClient();
            var newsTask = await client.GetStringAsync("http://localhost/webapp1/api/news");
            var news = JsonConvert.DeserializeObject<NewsItem[]>(newsTask);
            return news;
        }

        public async Task<ActionResult> ContactAsync()
        {
            var model = new HomeViewModel();

            ViewBag.Message = "Your Async page.";
            await Task.Delay(1000);
            return View(model);
        }
        public ActionResult ContactSync()
        {
            var model = new HomeViewModel();

            ViewBag.Message = "Your Sync page.";
            Thread.Sleep(1000);
            return View(model);
        }

        public async void LogStuff(string logMessage)
        {
            await Task.Delay(1000);
            Debug.Write(logMessage);
            throw new Exception("WTF!");
        }
    }
}