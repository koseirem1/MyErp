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

using MyERP.Model;
using MyERP.Service;

namespace MyERP.Admin.Controllers
{
    [Authorize]
    public class TaxesController : Controller
    {
       
        private readonly ITaxService taxService;

        public TaxesController(ITaxService taxService)
        {
            this.taxService = taxService;
        }

        // GET: Taxes
        public ActionResult Index()
        {
            var taxes = Mapper.Map<IEnumerable<TaxViewModel>>(taxService.GetAll());
            return View(taxes);
        }

        // GET: Taxes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxViewModel tax = Mapper.Map<TaxViewModel>(taxService.Get(id.Value)); ;
            if (tax == null)
            {
                return HttpNotFound();
            }
            return View(tax);
        }

        // GET: Taxes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Taxes/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( TaxViewModel tax)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Tax>(tax);
                taxService.Insert(entity);
                return RedirectToAction("Index");
            }

            return View(tax);
        }

        // GET: Taxes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxViewModel tax = Mapper.Map<TaxViewModel>(taxService.Get(id.Value));
            if (tax == null)
            {
                return HttpNotFound();
            }
            return View(tax);
        }

        // POST: Taxes/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( TaxViewModel tax)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Tax>(tax);
                taxService.Update(entity);
                return RedirectToAction("Index");
            }
            return View(tax);
        }

        // GET: Taxes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxViewModel tax = Mapper.Map<TaxViewModel>(taxService.Get(id.Value));
            if (tax == null)
            {
                return HttpNotFound();
            }
            return View(tax);
        }

        // POST: Taxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {

            taxService.Delete(id);
            return RedirectToAction("Index");
            
        }

        
    }
}
