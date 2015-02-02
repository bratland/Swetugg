using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    [SessionState(SessionStateBehavior.ReadOnly)]
    public class NewsItemsController : Controller
    {

        [HttpGet]
        public ActionResult GetNewsAsJson()
        {
            var news = new[]
            {
                new NewsItem {Id = 1, Description = "Swetugg rocks!!!"},
                new NewsItem {Id = 2, Description = "Stockholm is the greatest city in sweden!"}
            };
            return Json(news, JsonRequestBehavior.AllowGet);
        }

    





    private NewsContext db = new NewsContext();

        // GET: NewsItems
        public async Task<ActionResult> Index()
        {
            return View(await db.NewsItems.ToListAsync());
        }

        // GET: NewsItems/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsItem newsItem = await db.NewsItems.FindAsync(id);
            if (newsItem == null)
            {
                return HttpNotFound();
            }
            return View(newsItem);
        }

        // GET: NewsItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Description")] NewsItem newsItem)
        {
            if (ModelState.IsValid)
            {
                db.NewsItems.Add(newsItem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(newsItem);
        }

        // GET: NewsItems/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsItem newsItem = await db.NewsItems.FindAsync(id);
            if (newsItem == null)
            {
                return HttpNotFound();
            }
            return View(newsItem);
        }

        // POST: NewsItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Description")] NewsItem newsItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsItem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(newsItem);
        }

        // GET: NewsItems/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsItem newsItem = await db.NewsItems.FindAsync(id);
            if (newsItem == null)
            {
                return HttpNotFound();
            }
            return View(newsItem);
        }

        // POST: NewsItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            NewsItem newsItem = await db.NewsItems.FindAsync(id);
            db.NewsItems.Remove(newsItem);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
