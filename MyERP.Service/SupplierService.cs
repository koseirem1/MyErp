using MyERP.Data;
using MyERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Service
{
   public class SupplierService:ISupplierService
    {
        private readonly IRepository<Supplier> supplierRepository;
        private readonly UnitOfWork unitOfWork;

        public SupplierService(IRepository<Supplier> supplierRepository, UnitOfWork unitOfWork)
        {
            this.supplierRepository = supplierRepository;
            this.unitOfWork = unitOfWork;
        }

        public bool Any(Guid id)
        {
            return supplierRepository.Any(a => a.Id == id);
        }

        public void Delete(Guid id)
        {
            var supplier = supplierRepository.Get(id);
            if (supplier != null)
            {
                supplierRepository.Delete(supplier);
                unitOfWork.SaveChanges();
            }
        }

        public Supplier Get(Guid id)
        {
            return supplierRepository.Get(id);
        }

        public IEnumerable<Supplier> GetAll()
        {
            return supplierRepository.GetAll();
        }

        public void Insert(Supplier supplier)
        {
            supplierRepository.Insert(supplier);
            unitOfWork.SaveChanges();
        }

        public void Update(Supplier supplier)
        {
            supplierRepository.Update(supplier);
            unitOfWork.SaveChanges();
        }
    }

    public interface ISupplierService
    {
        IEnumerable<Supplier> GetAll();
        Supplier Get(Guid id);
        void Insert(Supplier supplier);
        void Update(Supplier supplier);
        void Delete(Guid id);
        bool Any(Guid id);
    }
}
