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
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            var customerViewModels = db.CustomerViewModels.Include(c => c.City).Include(c => c.Country);
            return View(customerViewModels.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerViewModel customerViewModel = db.CustomerViewModels.Find(id);
            if (customerViewModel == null)
            {
                return HttpNotFound();
            }
            return View(customerViewModel);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name");
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name");
            return View();
        }

        // POST: Customers/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,TitleOfCourtesy,Gender,MobilePhone,Email,Company,Address,CountryId,CityId,Photo,IsActive,CityName,CountryName")] CustomerViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                customerViewModel.Id = Guid.NewGuid();
                db.CustomerViewModels.Add(customerViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", customerViewModel.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", customerViewModel.CountryId);
            return View(customerViewModel);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerViewModel customerViewModel = db.CustomerViewModels.Find(id);
            if (customerViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", customerViewModel.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", customerViewModel.CountryId);
            return View(customerViewModel);
        }

        // POST: Customers/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,TitleOfCourtesy,Gender,MobilePhone,Email,Company,Address,CountryId,CityId,Photo,IsActive,CityName,CountryName")] CustomerViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", customerViewModel.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", customerViewModel.CountryId);
            return View(customerViewModel);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerViewModel customerViewModel = db.CustomerViewModels.Find(id);
            if (customerViewModel == null)
            {
                return HttpNotFound();
            }
            return View(customerViewModel);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CustomerViewModel customerViewModel = db.CustomerViewModels.Find(id);
            db.CustomerViewModels.Remove(customerViewModel);
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
