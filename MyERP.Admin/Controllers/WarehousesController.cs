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
    [Authorize]
    public class WarehousesController : Controller
    {
        private readonly IWarehouseService warehouseService;

        public WarehousesController(IWarehouseService warehouseService)
        {
            this.warehouseService = warehouseService;
        }
        // GET: Warehouses
        public ActionResult Index()
        {
            var warehouses = Mapper.Map<IEnumerable<WarehouseViewModel>>(warehouseService.GetAll());
            return View(warehouses);
        }

        // GET: Warehouses/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseViewModel warehouse = Mapper.Map<WarehouseViewModel>(warehouseService.Get(id.Value));
            if (warehouse == null)
            {
                return HttpNotFound();
            }
            return View(warehouse);
        }

        // GET: Warehouses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Warehouses/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WarehouseViewModel warehouse)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Warehouse>(warehouse);
                warehouseService.Insert(entity);
                return RedirectToAction("Index");
            }

            return View(warehouse);
        }

        // GET: Warehouses/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseViewModel warehouse = Mapper.Map<WarehouseViewModel>(warehouseService.Get(id.Value));
            if (warehouse == null)
            {
                return HttpNotFound();
            }
            return View(warehouse);
        }

        // POST: Warehouses/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WarehouseViewModel warehouse)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Warehouse>(warehouse);
                warehouseService.Update(entity);
                return RedirectToAction("Index");
            }
            return View(warehouse);
        }

        // GET: Warehouses/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseViewModel warehouse = Mapper.Map<WarehouseViewModel>(warehouseService.Get(id.Value));
            if (warehouse == null)
            {
                return HttpNotFound();
            }
            return View(warehouse);
        }

        // POST: Warehouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            warehouseService.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
