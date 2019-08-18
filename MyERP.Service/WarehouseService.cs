using MyERP.Data;
using MyERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Service
{
    public class WarehouseService:IWarehouseService
    {
        private readonly IRepository<Warehouse> warehouseRepository;
        private readonly IUnitOfWork unitOfWork;

        public WarehouseService(IRepository<Warehouse> warehouseRepository, IUnitOfWork unitOfWork)
        {
            this.warehouseRepository = warehouseRepository;
            this.unitOfWork = unitOfWork;
        }

        public bool Any(Guid id)
        {
            return warehouseRepository.Any(x => x.Id == id);
        }

        public void Delete(Guid id)
        {
            var warehouse = warehouseRepository.Get(id);
            if (warehouse != null)
            {
                warehouseRepository.Delete(warehouse);
                unitOfWork.SaveChanges();
            }
        }

        public Warehouse Get(Guid id)
        {
            return warehouseRepository.Get(id);
        }

        public IEnumerable<Warehouse> GetAll()
        {
            return warehouseRepository.GetAll();
        }

        public void Insert(Warehouse warehouse)
        {
            warehouseRepository.Insert(warehouse);
            unitOfWork.SaveChanges();
        }

        public void Update(Warehouse warehouse)
        {
            warehouseRepository.Update(warehouse);
            unitOfWork.SaveChanges();
        }
    }

    public interface IWarehouseService
    {
        IEnumerable<Warehouse> GetAll();
        Warehouse Get(Guid id);
        void Insert(Warehouse warehouse);
        void Update(Warehouse warehouse);
        void Delete(Guid id);
        bool Any(Guid id);
    }
}
