using entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IOrderService
    { 
        Task<Order> addNewOrder(Order order);
        Task<List<Order>> GetAllOrders();

    }
}
