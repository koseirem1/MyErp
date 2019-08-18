using MyERP.Data;
using MyERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Service
{
    public class ProductService:IProductService
    {
        private readonly IRepository<Product> productRepository;
        private readonly UnitOfWork unitOfWork;

        public ProductService(IRepository<Product> productRepository, UnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }

        public bool Any(Guid id)
        {
            return productRepository.Any(a => a.Id == id);
        }

        public void Delete(Guid id)
        {
            var product = productRepository.Get(id);
            if (product != null)
            {
                productRepository.Delete(product);
                unitOfWork.SaveChanges();
            }
        }

        public Product Get(Guid id)
        {
            return productRepository.Get(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return productRepository.GetAll();
        }

        public void Insert(Product product)
        {
            productRepository.Insert(product);
            unitOfWork.SaveChanges();
        }

        public void Update(Product product)
        {
            productRepository.Update(product);
            unitOfWork.SaveChanges();
        }
    }

    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product Get(Guid id);
        void Insert(Product product);
        void Update(Product product);
        void Delete(Guid id);
        bool Any(Guid id);
    }
}
