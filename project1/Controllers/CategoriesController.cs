using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.Net;
using System.IO;
using System.Web.Mvc;
using project1.DAL;
using project1.Models;

namespace project1.Controllers
{
    public class CategoriesController : Controller
    {
        private Sample db = new Sample();
        // GET: Categories
        public ActionResult Index(string pencarian)
        {
            var categori = from c in db.Categories
                           select c;
            if (!String.IsNullOrEmpty( pencarian))
            {
                categori = categori.Where(c => c.CategoryName.Contains(pencarian));
            }
            return View(categori);
        }
        


        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                // TODO: Add insert logic here
                CategoriesDAL cat = new CategoriesDAL();
                cat.Create(category);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category categori = db.Categories.Find(id);
            if (categori == null)
            {
                return HttpNotFound();
            }

            return View(categori);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category categori)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categori);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category categori = db.Categories.Find(id);
            if (categori == null)
            {
                return HttpNotFound();
            }
            return View(categori);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Category categori = db.Categories.Find(id);
            if (categori==null)
            {
                return HttpNotFound();
            }
            db.Categories.Remove(categori);
            db.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
