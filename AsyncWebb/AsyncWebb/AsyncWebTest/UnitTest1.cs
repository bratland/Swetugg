using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApp1.Controllers;
using WebApp1.Models;

namespace AsyncWebTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var homeController = new HomeController();
            var result = await homeController.About() as ViewResult;
            Assert.IsTrue((result.Model as HomeViewModel).News.Count() == 2);
        }
    }
}
