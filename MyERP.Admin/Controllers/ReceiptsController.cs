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
    public class ReceiptsController : Controller
    {
        private readonly IReceiptService receiptService;
        private readonly ICustomerService customerService;
        private readonly IBankService bankService;

        public ReceiptsController(IReceiptService receiptService, ICustomerService customerService, IBankService bankService)
        {
            this.receiptService = receiptService;
            this.customerService = customerService;
            this.bankService = bankService;
        }
        [HttpPost]
        public ActionResult AddCustomer(string firstName, string lastName, TitleOfCourtesy titleofCourtesy, string contactCompany, string contactPosta, string contactPhone)
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

        // GET: Receipts
        public ActionResult Index()
        {
            var receipts = Mapper.Map<IEnumerable<ReceiptViewModel>>(receiptService.GetAll());
            return View(receipts);
        }

        // GET: Receipts/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiptViewModel receipt = Mapper.Map<ReceiptViewModel>(receiptService.Get(id.Value));
            if (receipt == null)
            {
                return HttpNotFound();
            }
            return View(receipt);
        }

        // GET: Receipts/Create
        public ActionResult Create()
        {
            ViewBag.BankId = new SelectList(bankService.GetAll(), "Id", "Name");
            ViewBag.CustomerId = new SelectList(customerService.GetAll(), "Id", "FullName");
            return View();
        }

        // POST: Receipts/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReceiptViewModel receipt)
        {
            if (ModelState.IsValid)
            {

                var entity = Mapper.Map<Receipt>(receipt);
                receiptService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.BankId = new SelectList(bankService.GetAll(), "Id", "Name");
            ViewBag.CustomerId = new SelectList(customerService.GetAll(), "Id", "FullName");

            return View(receipt);
        }

        // GET: Receipts/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiptViewModel receipt = Mapper.Map<ReceiptViewModel>(receiptService.Get(id.Value));
            if (receipt == null)
            {
                return HttpNotFound();
            }
            ViewBag.BankId = new SelectList(bankService.GetAll(), "Id", "Name");
            ViewBag.CustomerId = new SelectList(customerService.GetAll(), "Id", "FullName");

            return View(receipt);
        }

        // POST: Receipts/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReceiptViewModel receipt)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Receipt>(receipt);
                receiptService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.BankId = new SelectList(bankService.GetAll(), "Id", "Name");
            ViewBag.CustomerId = new SelectList(customerService.GetAll(), "Id", "FullName");

            return View(receipt);
        }

        // GET: Receipts/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiptViewModel receipt = Mapper.Map<ReceiptViewModel>(receiptService.Get(id.Value));
            if (receipt == null)
            {
                return HttpNotFound();
            }
            return View(receipt);
        }

        // POST: Receipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            receiptService.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
