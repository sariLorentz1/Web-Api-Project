using entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrderService : IOrderService
    {
        IOrderRepository repository;
        public OrderService(IOrderRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Order> addNewOrder(Order order)
        {
            return await this.repository.addNewOrder(order);
        }
        public async Task<List<Order>> GetAllOrders() => await repository.GetAllOrders();

    }
}


