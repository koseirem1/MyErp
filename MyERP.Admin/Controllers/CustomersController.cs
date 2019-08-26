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
    public class CustomersController : Controller
    {
       
        private readonly ICustomerService customerService;
        private readonly ICityService cityService;
        private readonly ICountryService countryService;
        public CustomersController(ICustomerService customerService, ICityService cityService, ICountryService countryService)
        {
            this.customerService = customerService;
            this.cityService = cityService;
            this.countryService = countryService;
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = Mapper.Map<IEnumerable<CustomerViewModel>>(customerService.GetAll());
            return View(customers);
        }
     
        // GET: Customers/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CustomerViewModel customer = Mapper.Map<CustomerViewModel>(customerService.Get(id.Value));
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "Name");
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Customers/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Customer>(customer);
                customerService.Insert(entity);
                return RedirectToAction("Index");
               
            }

            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "Name", customer.CityId);
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name", customer.CountryId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerViewModel customer = Mapper.Map<CustomerViewModel>(customerService.Get(id.Value));
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "Name", customer.CityId);
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name", customer.CountryId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Customer>(customer);
                customerService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "Name", customer.CityId);
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name", customer.CountryId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerViewModel customer = Mapper.Map<CustomerViewModel>(customerService.Get(id.Value));
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            customerService.Delete(id);
            return RedirectToAction("Index");
           
        }

      
    }
}
