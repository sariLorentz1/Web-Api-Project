using entities;
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

        public async Task<IEnumerable<Product>> getProducts(int[]? categryIds, int? minPrice, int? maxPrice, string? productName, string? description)
        {
            return await repository.getProducts(categryIds,minPrice,maxPrice,productName,description);
        }
    }
}
