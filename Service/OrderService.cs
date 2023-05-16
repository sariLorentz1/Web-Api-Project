using entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Service
{
    public class OrderService : IOrderService
    {
        IOrderRepository _repository;
        ILogger<OrderService> _logger;
        IProductRepository _productRepository;
        private async Task<bool> ValidateOrderSum(Order order)
        {
            int sum = 0;

            foreach (OrderItem orderItem in order.OrderItems)
            {
                Product p = await _productRepository.GetProductById((int)orderItem.ProductId);
                (sum) += (int)(p.Price) * (int)orderItem.Quantity;
            }
            return sum == order.Sum;
        }
        public OrderService(IOrderRepository repository, IProductRepository productRepository, ILogger<OrderService> logger)

        {
            _repository = repository;
            _productRepository = productRepository;
            _logger = logger;
        }
        public async Task<Order> addNewOrder(Order order)
        {

            if (!await ValidateOrderSum(order))
            {
                _logger.LogWarning("Mismatch in order sum");
                return order;
            }
            return await _repository.addNewOrder(order);
        }
        public async Task<List<Order>> GetAllOrders() => await _repository.GetAllOrders();

        public async Task<Order> getOrderAsync(int id)
        {
            return await _repository.getOrderAsync(id);
        }



    }
}


