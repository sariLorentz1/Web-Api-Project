using entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IOrderRepository
    {
        Task<Order> addNewOrder(Order order);
        Task<List<Order>> GetAllOrders();

    }
}
