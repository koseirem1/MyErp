using MyERP.Data;
using MyERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Service
{
   public class ReceiptService:IReceiptService
    {
        private readonly IRepository<Receipt> receiptRepository;
        private readonly IUnitOfWork unitOfWork;

        public ReceiptService(IRepository<Receipt> receiptRepository, IUnitOfWork unitOfWork)
        {
            this.receiptRepository = receiptRepository;
            this.unitOfWork = unitOfWork;
        }

        public bool Any(Guid id)
        {
            return receiptRepository.Any(a => a.Id == id);
        }

        public void Delete(Guid id)
        {
            var receipt = receiptRepository.Get(id);
            if (receipt != null)
            {
                receiptRepository.Delete(receipt);
                unitOfWork.SaveChanges();
            }
        }

        public Receipt Get(Guid id)
        {
            return receiptRepository.Get(id);
        }

        public IEnumerable<Receipt> GetAll()
        {
            return receiptRepository.GetAll();
        }

        public void Insert(Receipt receipt)
        {
            receiptRepository.Insert(receipt);
            unitOfWork.SaveChanges();
        }

        public void Update(Receipt receipt)
        {
            receiptRepository.Update(receipt);
            unitOfWork.SaveChanges();
        }
    }

    public interface IReceiptService
    {
        IEnumerable<Receipt> GetAll();
        Receipt Get(Guid id);
        void Insert(Receipt receipt);
        void Update(Receipt receipt);
        void Delete(Guid id);
        bool Any(Guid id);
    }
}
