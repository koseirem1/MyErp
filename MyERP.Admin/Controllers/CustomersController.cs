using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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

        [HttpPost]
        public ActionResult GetCities(Guid countryId)
        {
            var cities = Mapper.Map<IEnumerable<CityViewModel>>(cityService.GetAllByCountryId(countryId));
            return Json(cities);
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
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name");
            ViewBag.CityId = new SelectList(cityService.GetAllByCountryId(Guid.NewGuid()), "Id", "Name");
            
            return View();
        }

        // POST: Customers/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( CustomerViewModel customer, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    customer.Photo = UploadFile(upload);
                }
                catch(Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return View(customer);
                }
                var entity = Mapper.Map<Customer>(customer);
                customerService.Insert(entity);
                return RedirectToAction("Index");
               
            }

            ViewBag.CityId = new SelectList(cityService.GetAllByCountryId(customer.CountryId ?? Guid.NewGuid()), "Id", "Name", customer.CityId);
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name", customer.CountryId);
            return View(customer);
        }
        public string UploadFile(HttpPostedFileBase upload)
        {
            
            if (upload != null && upload.ContentLength > 0)
            {
                
                var extension = Path.GetExtension(upload.FileName).ToLower();
                if (extension == ".jpg" || extension == ".jpeg" ||  extension == ".png")
                {
                    
                    if (Directory.Exists(Server.MapPath("~/Uploads")))
                    {
                        
                        string fileName = upload.FileName.ToLower();
                        fileName = fileName.Replace("İ", "i");
                        fileName = fileName.Replace("Ş", "s");
                        fileName = fileName.Replace("Ğ", "g");
                        fileName = fileName.Replace("ğ", "g");
                        fileName = fileName.Replace("ı", "i");
                        fileName = fileName.Replace("(", "");
                        fileName = fileName.Replace(")", "");
                        fileName = fileName.Replace(" ", "-");
                        fileName = fileName.Replace(",", "");
                        fileName = fileName.Replace("ö", "o");
                        fileName = fileName.Replace("ü", "u");
                        fileName = fileName.Replace("`", "");
                        
                        fileName = DateTime.Now.Ticks.ToString() + fileName;

                       
                        upload.SaveAs(Path.Combine(Server.MapPath("~/Uploads"), fileName));

                       
                        return fileName;
                    }
                    else
                    {
                        throw new Exception("Uploads dizini mevcut değil.");
                    }
                }
                else
                {
                    throw new Exception("Dosya uzantısı jpg, jpeg veya png olmalıdır.");
                }
            }
            return null;
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
        public ActionResult Edit( CustomerViewModel customer, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        customer.Photo = UploadFile(upload);
                    }

                }
                catch(Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return View(customer);

                }
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
