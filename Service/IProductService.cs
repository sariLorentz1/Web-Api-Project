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
        Task<IEnumerable<Product>> getProducts(IEnumerable<string>? categories, string? name, int? minPrice, int? maxPrice);
    }
}
