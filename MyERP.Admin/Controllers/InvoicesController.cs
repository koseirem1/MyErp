using AutoMapper;
using MyERP.Admin.Models;
using MyERP.Model;
using MyERP.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyERP.Admin.Controllers
{
    [Authorize]
    public class InvoicesController : Controller
    {
       
            private readonly IInvoiceService invoiceService;
            private readonly ICustomerService customerService;
            private readonly IProductService productService;
            private readonly ITaxService taxService;


            public InvoicesController(IInvoiceService invoiceService, ICustomerService customerService, IProductService productService, ITaxService taxService)
            {
                this.invoiceService = invoiceService;
                this.customerService = customerService;
                this.productService = productService;
                this.taxService = taxService;
            }

            // GET: Invoices
            public ActionResult Index()
            {
                var invoices = Mapper.Map<IEnumerable<InvoiceViewModel>>(invoiceService.GetAll());
                return View(invoices);
            }

            // GET: Invoices/Details/5
            public ActionResult Details(Guid? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                InvoiceViewModel invoice = Mapper.Map<InvoiceViewModel>(invoiceService.Get(id.Value));
                if (invoice == null)
                {
                    return HttpNotFound();
                }
                return View(invoice);
            }

            // GET: Invoices/Create
            public ActionResult Create()
            {
                ViewBag.CustomerId = new SelectList(customerService.GetAll(), "Id", "FullName");
                ViewBag.ProductId = new SelectList(productService.GetAll(), "Id", "Name");
                ViewBag.TaxId = new SelectList(taxService.GetAll(), "Id", "Name");
                return View();
            }

            // POST: Invoices/Create
            // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
            // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(InvoiceViewModel invoice)
            {
                if (ModelState.IsValid)
                {
                    var entity = Mapper.Map<Invoice>(invoice);
                    invoiceService.Insert(entity);
                    return RedirectToAction("Index");
                }

                ViewBag.CustomerId = new SelectList(customerService.GetAll(), "Id", "FullName", invoice.CustomerId);
                ViewBag.ProductId = new SelectList(productService.GetAll(), "Id", "Name", invoice.ProductId);
                ViewBag.TaxId = new SelectList(taxService.GetAll(), "Id", "Name", invoice.TaxId);
                return View(invoice);
            }

            // GET: Invoices/Edit/5
            public ActionResult Edit(Guid? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                InvoiceViewModel invoice = Mapper.Map<InvoiceViewModel>(invoiceService.Get(id.Value));
                if (invoice == null)
                {
                    return HttpNotFound();
                }
                ViewBag.CustomerId = new SelectList(customerService.GetAll(), "Id", "FullName", invoice.CustomerId);
                ViewBag.ProductId = new SelectList(productService.GetAll(), "Id", "Name", invoice.ProductId);
                ViewBag.TaxId = new SelectList(taxService.GetAll(), "Id", "Name", invoice.TaxId);
                return View(invoice);
            }

            // POST: Invoices/Edit/5
            // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
            // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(InvoiceViewModel invoice)
            {
                if (ModelState.IsValid)
                {
                    var entity = Mapper.Map<Invoice>(invoice);
                    invoiceService.Update(entity);
                    return RedirectToAction("Index");
                }
                ViewBag.CustomerId = new SelectList(customerService.GetAll(), "Id", "FullName", invoice.CustomerId);
                ViewBag.ProductId = new SelectList(productService.GetAll(), "Id", "Name", invoice.ProductId);
                ViewBag.TaxId = new SelectList(taxService.GetAll(), "Id", "Name", invoice.TaxId);
                return View(invoice);
            }

            // GET: Invoices/Delete/5
            public ActionResult Delete(Guid? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                InvoiceViewModel invoice = Mapper.Map<InvoiceViewModel>(invoiceService.Get(id.Value));
                if (invoice == null)
                {
                    return HttpNotFound();
                }
                return View(invoice);
            }

            // POST: Invoices/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(Guid id)
            {
                invoiceService.Delete(id);
                return RedirectToAction("Index");

            }


        }
    }
