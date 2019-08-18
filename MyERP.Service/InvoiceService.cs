using MyERP.Data;
using MyERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Service
{
   public class InvoiceService:IInvoiceService
    {
        private readonly IRepository<Invoice> invoiceRepository;
        private readonly IUnitOfWork unitOfWork;

        public InvoiceService(IRepository<Invoice> invoiceRepository, IUnitOfWork unitOfWork)
        {
            this.invoiceRepository = invoiceRepository;
            this.unitOfWork = unitOfWork;
        }

        public bool Any(Guid id)
        {
           return invoiceRepository.Any(x=>x.Id==id);
        }

        public void Delete(Guid id)
        {
            var invoice = invoiceRepository.Get(id);
            if (invoice != null)
            {
                invoiceRepository.Delete(invoice);
                unitOfWork.SaveChanges();
            }
        }

        public Invoice Get(Guid id)
        {
            return invoiceRepository.Get(id);
        }

        public IEnumerable<Invoice> GetAll()
        {
            return invoiceRepository.GetAll();
        }

        public void Insert(Invoice invoice)
        {
            invoiceRepository.Insert(invoice);
            unitOfWork.SaveChanges();
        }

        public void Update(Invoice invoice)
        {
            invoiceRepository.Update(invoice);
            unitOfWork.SaveChanges();
        }
    }

    public interface IInvoiceService
    {
        IEnumerable<Invoice> GetAll();
        Invoice Get(Guid id);
        void Insert(Invoice invoice);
        void Update(Invoice invoice);
        void Delete(Guid id);
        bool Any(Guid id);
    }
}
