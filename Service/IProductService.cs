using entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IProductService
    {
        Task<Product> addNewProduct(Product product);
        Task<IEnumerable<Product>> getProducts(int[]? categryIds, int? minPrice, int? maxPrice, string? productName, string? description);
    }
}
