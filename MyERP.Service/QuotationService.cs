using MyERP.Data;
using MyERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Service
{
    public class QuotationService:IQuotationService
    {
        private readonly IRepository<Quotation> quotationRepository;
        private readonly IUnitOfWork unitOfWork;

        public QuotationService(IRepository<Quotation> quotationRepository, IUnitOfWork unitOfWork)
        {
            this.quotationRepository = quotationRepository;
            this.unitOfWork = unitOfWork;
        }

        public bool Any(Guid id)
        {
            return quotationRepository.Any(a => a.Id == id);
        }

        public void Delete(Guid id)
        {
            var quotation = quotationRepository.Get(id);
            if (quotation != null)
            {
                quotationRepository.Delete(quotation);
                unitOfWork.SaveChanges();
            }
        }

        public Quotation Get(Guid id)
        {
            return quotationRepository.Get(id);
        }

        public IEnumerable<Quotation> GetAll()
        {
            return quotationRepository.GetAll();
        }

        public void Insert(Quotation quotation)
        {
            quotationRepository.Insert(quotation);
            unitOfWork.SaveChanges();
        }

        public void Update(Quotation quotation)
        {
            quotationRepository.Update(quotation);
            unitOfWork.SaveChanges();
        }
    }

    public interface IQuotationService
    {
        IEnumerable<Quotation> GetAll();
        Quotation Get(Guid id);
        void Insert(Quotation quotation);
        void Update(Quotation quotation);
        void Delete(Guid id);
        bool Any(Guid id);
    }
}
