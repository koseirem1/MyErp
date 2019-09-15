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

    public class QuotationsController : Controller
        {
            private readonly IQuotationService quotationService;
            private readonly ICustomerService customerService;
            private readonly IProductService productService;
            private readonly ITaxService taxService;


            public QuotationsController(IQuotationService quotationService, ICustomerService customerService, IProductService productService, ITaxService taxService)
            {
                this.quotationService = quotationService;
                this.customerService = customerService;
                this.productService = productService;
                this.taxService = taxService;
            }
        [HttpPost]
        public ActionResult AddCustomer(string firstName, string lastName,TitleOfCourtesy titleofCourtesy ,string contactCompany, string contactPosta, string contactPhone)
        {
            try
            {
                var customer = new Customer();
                customer.FirstName = firstName;
                customer.LastName = lastName;
                customer.TitleOfCourtesy = titleofCourtesy;
                customer.Company = contactCompany;
                customer.Email = contactPosta;
                customer.MobilePhone = contactPhone;
                customerService.Insert(customer);
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        [HttpPost]
        public ActionResult GetCustomers()
        {
            return Json(Mapper.Map<IEnumerable<CustomerViewModel>>(customerService.GetAll()));
        }
        // GET: Quotations
        public ActionResult Index()
            {
                var quotations = Mapper.Map<IEnumerable<QuotationViewModel>>(quotationService.GetAll());
                return View(quotations);
            }

            // GET: Quotations/Details/5
            public ActionResult Details(Guid? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                QuotationViewModel quotation = Mapper.Map<QuotationViewModel>(quotationService.Get(id.Value));
                if (quotation == null)
                {
                    return HttpNotFound();
                }
                return View(quotation);
            }

            // GET: Quotations/Create
            public ActionResult Create()
            {
                ViewBag.CustomerId = new SelectList(customerService.GetAll(), "Id", "FullName");
                ViewBag.ProductId = new SelectList(productService.GetAll(), "Id", "Name");
                ViewBag.TaxId = new SelectList(taxService.GetAll(), "Id", "Name");
                return View();
            }

            // POST: Quotations/Create
            // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
            // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(QuotationViewModel quotation)
            {
                if (ModelState.IsValid)
                {
                    var entity = Mapper.Map<Quotation>(quotation);
                    quotationService.Insert(entity);
                    return RedirectToAction("Index");
                }

                ViewBag.CustomerId = new SelectList(customerService.GetAll(), "Id", "FullName");
                ViewBag.ProductId = new SelectList(productService.GetAll(), "Id", "Name");
                ViewBag.TaxId = new SelectList(taxService.GetAll(), "Id", "Name");
                return View(quotation);
            }

            // GET: Quotations/Edit/5
            public ActionResult Edit(Guid? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                QuotationViewModel quotation = Mapper.Map<QuotationViewModel>(quotationService.Get(id.Value));
                if (quotation == null)
                {
                    return HttpNotFound();
                }

                ViewBag.CustomerId = new SelectList(customerService.GetAll(), "Id", "FullName");
                ViewBag.ProductId = new SelectList(productService.GetAll(), "Id", "Name");
                ViewBag.TaxId = new SelectList(taxService.GetAll(), "Id", "Name");
                return View(quotation);
            }

            // POST: Quotations/Edit/5
            // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
            // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(QuotationViewModel quotation)
            {
                if (ModelState.IsValid)
                {
                    var entity = Mapper.Map<Quotation>(quotation);
                    quotationService.Update(entity);
                    return RedirectToAction("Index");
                }
                ViewBag.CustomerId = new SelectList(customerService.GetAll(), "Id", "FullName");
                ViewBag.ProductId = new SelectList(productService.GetAll(), "Id", "Name");
                ViewBag.TaxId = new SelectList(taxService.GetAll(), "Id", "Name");
                return View(quotation);
            }

            // GET: Quotations/Delete/5
            public ActionResult Delete(Guid? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                QuotationViewModel quotation = Mapper.Map<QuotationViewModel>(quotationService.Get(id.Value));
                if (quotation == null)
                {
                    return HttpNotFound();
                }
                return View(quotation);
            }

            // POST: Quotations/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(Guid id)
            {
                quotationService.Delete(id);
                return RedirectToAction("Index");
            }


        }
    }

