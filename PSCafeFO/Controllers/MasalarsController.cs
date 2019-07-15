using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PSCafeFO.Models;

namespace PSCafeFO.Controllers
{
    public class MasalarsController : Controller
    {
        private PSCafeEntities db = new PSCafeEntities();

        // GET: Masalars
        public ActionResult Index()
        {
            return View(db.Masalar.ToList());
        }

        // GET: Masalars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Masalar masalar = db.Masalar.Find(id);
            if (masalar == null)
            {
                return HttpNotFound();
            }
            return View(masalar);
        }

        // GET: Masalars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Masalars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MasaTuru,AcilisSaat,KapanisSaat,Fiyat,Durum")] Masalar masalar)
        {
            if (ModelState.IsValid)
            {
                db.Masalar.Add(masalar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(masalar);
        }









        // GET: Masalars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Masalar masalar = db.Masalar.Find(id);
            if (masalar == null)
            {
                return HttpNotFound();
            }
            return View(masalar);
        }

        // POST: Masalars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MasaTuru,AcilisSaat,KapanisSaat,Fiyat,Durum")] Masalar masalar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(masalar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(masalar);
        }























        // GET: Masalars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Masalar masalar = db.Masalar.Find(id);
            if (masalar == null)
            {
                return HttpNotFound();
            }
            return View(masalar);
        }


        // POST: Masalars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Masalar masalar = db.Masalar.Find(id);
            db.Masalar.Remove(masalar);
            db.SaveChanges();
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
