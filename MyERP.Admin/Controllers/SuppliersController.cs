using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MyERP.Admin.Models;
using MyERP.Data;
using MyERP.Model;
using MyERP.Service;

namespace MyERP.Admin.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISupplierService supplierService;
        private readonly ICityService cityService;
        private readonly ICountryService countryService;

        public SuppliersController(ISupplierService supplierService, ICityService cityService, ICountryService countryService)
        {
            this.supplierService = supplierService;
            this.cityService = cityService;
            this.countryService = countryService;
        }
        // GET: Suppliers
        public ActionResult Index()
        {
            var suppliers = Mapper.Map<IEnumerable<SupplierViewModel>>(supplierService.GetAll());
            return View(suppliers);
        }

        // GET: Suppliers/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierViewModel supplier = Mapper.Map<SupplierViewModel>(supplierService.Get(id.Value));
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // GET: Suppliers/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "Name");
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Suppliers/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( SupplierViewModel supplier)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Supplier>(supplier);
                supplierService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "Name");
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name");
            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierViewModel supplier = Mapper.Map<SupplierViewModel>(supplierService.Get(id.Value));
            if (supplier == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "Name");
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name");
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( SupplierViewModel supplier)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Supplier>(supplier);
                supplierService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "Name");
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name");
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierViewModel supplier = Mapper.Map<SupplierViewModel>(supplierService.Get(id.Value));
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            supplierService.Delete(id);
            return RedirectToAction("Index");
            
        }

        
    }
}
