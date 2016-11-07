using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Net;
using System.Data.Entity;
using System.IO;
using project1.DAL;
using project1.Models;
using project1.Controllers;

namespace project1.Controllers
{
    public class AuthorsController : Controller
    {
        private Sample db = new Sample();
        // GET: Authors
        public ActionResult Index()
        {
            AuthorsDAL auto = new AuthorsDAL();
            var models = auto.GetAll();
            return View(models);
        }

        // GET: Authors/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        [HttpPost]
        public ActionResult Create(Author author)
        {
            try
            {
                // TODO: Add insert logic here
                AuthorsDAL auto = new AuthorsDAL();
                auto.Create(author);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author authors = db.Authors.Find(id);
            if (authors == null)
            {
                return HttpNotFound();
            }

            return View(authors);
        }

        // POST: Authors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Author authors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(authors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(authors);
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Author authors = db.Authors.Find(id);
            if (authors == null)
            {
                return HttpNotFound();
            }
            return View(authors);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Author authors = db.Authors.Find(id);
            if (authors == null)
            {
                return HttpNotFound();
            }
            db.Authors.Remove(authors);
            db.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
