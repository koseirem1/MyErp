using MyERP.Data;
using MyERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Service
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> orderRepository;
        private readonly IUnitOfWork unitOfWork;

        public OrderService(IRepository<Order> orderRepository, IUnitOfWork unitOfWork)
        {
            this.orderRepository = orderRepository;
            this.unitOfWork = unitOfWork;
        }

        public bool Any(Guid id)
        {
            return orderRepository.Any(a=>a.Id==id);
        }

        public void Delete(Guid id)
        {
            var order=orderRepository.Get(id);
            if (order != null)
            {
                orderRepository.Delete(order);
                unitOfWork.SaveChanges();
            }
        }

        public Order Get(Guid id)
        {
            return orderRepository.Get(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return orderRepository.GetAll();
        }

        public void Insert(Order order)
        {
            orderRepository.Insert(order);
            unitOfWork.SaveChanges();
        }

        public void Update(Order order)
        {
            orderRepository.Update(order);
            unitOfWork.SaveChanges();
        }
    }

    public interface IOrderService
    {
        IEnumerable<Order> GetAll();
        Order Get(Guid id);
        void Insert(Order order);
        void Update(Order order);
        void Delete(Guid id);
        bool Any(Guid id);
    }
}
