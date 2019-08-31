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
   
    public class BanksController : Controller
    {
        private readonly ICountryService countryService;
        private readonly ICityService cityService;
        private readonly IBankService bankService;

        public BanksController(IBankService bankService, ICityService cityService, ICountryService countryService)
        {
            this.bankService = bankService;
            this.cityService = cityService;
            this.countryService = countryService;
        }


        // GET: Banks
        public ActionResult Index()
        {
            var banks = Mapper.Map<IEnumerable<BankViewModel>>(bankService.GetAll());
            return View(banks);
        }

        // GET: Banks/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankViewModel bank = Mapper.Map<BankViewModel>(bankService.Get(id.Value));
            if (bank == null)
            {
                return HttpNotFound();
            }
            return View(bank);
        }

        // GET: Banks/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "Name");
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Banks/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( BankViewModel bank)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Bank>(bank);
                bankService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "Name", bank.CityId);
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name", bank.CountryId);
            return View(bank);
        }

        // GET: Banks/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankViewModel bank = Mapper.Map<BankViewModel>(bankService.Get(id.Value));
            if (bank == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "Name", bank.CityId);
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name", bank.CountryId);
            return View(bank);
        }

        // POST: Banks/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( BankViewModel bank)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Bank>(bank);
                bankService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "Name", bank.CityId);
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name", bank.CountryId);
            return View(bank);
        }

        // GET: Banks/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankViewModel bank = Mapper.Map<BankViewModel>(bankService.Get(id.Value));
            if (bank == null)
            {
                return HttpNotFound();
            }
            return View(bank);
        }

        // POST: Banks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            bankService.Delete(id);
            return RedirectToAction("Index");
            
        }

       
    }
}
