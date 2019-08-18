using MyERP.Data;
using MyERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Service
{
    public class BankService : IBankService
    {
        private readonly IRepository<Bank> bankRepository;
        private readonly IUnitOfWork unitOfWork;

        public BankService(IRepository<Bank> bankRepository, IUnitOfWork unitOfWork)
        {
            this.bankRepository = bankRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Any(Guid id)
        {
            return bankRepository.Any(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            var bank = bankRepository.Get(id);
            if(bank != null)
            {
                bankRepository.Delete(bank);
                unitOfWork.SaveChanges();
            }
        }

        public Bank Get(Guid id)
        {
            return bankRepository.Get(id);
        }

        public IEnumerable<Bank> GetAll()
        {
            return bankRepository.GetAll();
        }

        public void Insert(Bank bank)
        {
            bankRepository.Insert(bank);
            unitOfWork.SaveChanges();
        }

        public void Update(Bank bank)
        {
            bankRepository.Update(bank);
            unitOfWork.SaveChanges();
        }
    }

    public interface IBankService
    {
        IEnumerable<Bank> GetAll();
        Bank Get(Guid id);
        void Insert(Bank bank);
        void Update(Bank bank);
        void Delete(Guid id);
        bool Any(Guid id);
    }
}
