using entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        IceShopContext dbContext = new IceShopContext();
        public OrderRepository(IceShopContext DBContext)
        {
            this.dbContext = DBContext;
        }
        public async Task<Order> addNewOrder(Order order)
        {
            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();
            return order;
        }
        public async Task<List<Order>> GetAllOrders() => await dbContext.Orders.ToListAsync();

    }
}
