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
    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;
        private readonly ICustomerService customerService;
        private readonly IProductService productService;
        private readonly ITaxService taxService;

        public OrdersController(IOrderService orderService, ICustomerService customerService, IProductService productService, ITaxService taxService)
        {
            this.orderService = orderService;
            this.customerService = customerService;
            this.productService = productService;
            this.taxService = taxService;
        }

        // GET: Orders
        public ActionResult Index()
        {
            var orders = Mapper.Map<IEnumerable<OrderViewModel>>(orderService.GetAll());
            return View(orders);
        }

        // GET: Orders/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderViewModel order = Mapper.Map<OrderViewModel>(orderService.Get(id.Value));
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(customerService.GetAll(), "Id", "FirstName");
            ViewBag.ProductId = new SelectList(productService.GetAll(), "Id", "Name");
            ViewBag.TaxId = new SelectList(taxService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Orders/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( OrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Order>(order); 
                orderService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(customerService.GetAll(), "Id", "FirstName", order.CustomerId);
            ViewBag.ProductId = new SelectList(productService.GetAll(), "Id", "Name", order.ProductId);
            ViewBag.TaxId = new SelectList(taxService.GetAll(), "Id", "Name", order.TaxId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderViewModel order = Mapper.Map<OrderViewModel>(orderService.Get(id.Value));
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(customerService.GetAll(), "Id", "FirstName", order.CustomerId);
            ViewBag.ProductId = new SelectList(productService.GetAll(), "Id", "Name", order.ProductId);
            ViewBag.TaxId = new SelectList(taxService.GetAll(), "Id", "Name", order.TaxId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( OrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Order>(order);
                orderService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(customerService.GetAll(), "Id", "FirstName", order.CustomerId);
            ViewBag.ProductId = new SelectList(productService.GetAll(), "Id", "Name", order.ProductId);
            ViewBag.TaxId = new SelectList(taxService.GetAll(), "Id", "Name", order.TaxId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderViewModel order = Mapper.Map<OrderViewModel>(orderService.Get(id.Value));
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            orderService.Delete(id);
            return RedirectToAction("Index");
        }

        
    }
}
