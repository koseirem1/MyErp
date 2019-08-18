using MyERP.Data;
using MyERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Service
{
    public class TaxService:ITaxService
    {
        private readonly IRepository<Tax> taxRepository;
        private readonly IUnitOfWork unitOfWork;

        public TaxService(IRepository<Tax> taxRepository, IUnitOfWork unitOfWork)
        {
            this.taxRepository = taxRepository;
            this.unitOfWork = unitOfWork;
        }

        public bool Any(Guid id)
        {
            return taxRepository.Any(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            var tax = taxRepository.Get(id);
            if (tax != null)
            {
                taxRepository.Delete(tax);
                unitOfWork.SaveChanges();
            }
        }

        public Tax Get(Guid id)
        {
            return taxRepository.Get(id);
        }

        public IEnumerable<Tax> GetAll()
        {
            return taxRepository.GetAll();
        }

        public void Insert(Tax tax)
        {
            taxRepository.Insert(tax);
            unitOfWork.SaveChanges();
        }

        public void Update(Tax tax)
        {
            taxRepository.Update(tax);
            unitOfWork.SaveChanges();
        }
    }

    public interface ITaxService
    {
        IEnumerable<Tax> GetAll();
        Tax Get(Guid id);
        void Insert(Tax tax);
        void Update(Tax tax);
        void Delete(Guid id);
        bool Any(Guid id);
    }
}
