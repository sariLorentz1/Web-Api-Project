using entities;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService : IProductService
    {
        IProductRepository repository;

        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Product> addNewProduct(Product product)
        {
            return await repository.addNewProduct(product);
        }

        public async Task<IEnumerable<Product>> getProducts(IEnumerable<string>? categories, string? name, int? minPrice, int? maxPrice)
        {
            return await repository.getProducts(categories, name,  minPrice, maxPrice);
        }
    }
}
