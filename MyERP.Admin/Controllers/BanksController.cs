using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyERP.Admin.Models;
using MyERP.Data;

namespace MyERP.Admin.Controllers
{
    public class BanksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Banks
        public ActionResult Index()
        {
            var bankViewModels = db.BankViewModels.Include(b => b.City).Include(b => b.Country);
            return View(bankViewModels.ToList());
        }

        // GET: Banks/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankViewModel bankViewModel = db.BankViewModels.Find(id);
            if (bankViewModel == null)
            {
                return HttpNotFound();
            }
            return View(bankViewModel);
        }

        // GET: Banks/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name");
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name");
            return View();
        }

        // POST: Banks/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,CountryId,CityId,Account,OpenBalance,CloseBalance,IsActive,CityName,CountryName")] BankViewModel bankViewModel)
        {
            if (ModelState.IsValid)
            {
                bankViewModel.Id = Guid.NewGuid();
                db.BankViewModels.Add(bankViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", bankViewModel.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", bankViewModel.CountryId);
            return View(bankViewModel);
        }

        // GET: Banks/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankViewModel bankViewModel = db.BankViewModels.Find(id);
            if (bankViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", bankViewModel.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", bankViewModel.CountryId);
            return View(bankViewModel);
        }

        // POST: Banks/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,CountryId,CityId,Account,OpenBalance,CloseBalance,IsActive,CityName,CountryName")] BankViewModel bankViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bankViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", bankViewModel.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", bankViewModel.CountryId);
            return View(bankViewModel);
        }

        // GET: Banks/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankViewModel bankViewModel = db.BankViewModels.Find(id);
            if (bankViewModel == null)
            {
                return HttpNotFound();
            }
            return View(bankViewModel);
        }

        // POST: Banks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            BankViewModel bankViewModel = db.BankViewModels.Find(id);
            db.BankViewModels.Remove(bankViewModel);
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
