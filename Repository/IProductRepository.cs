using entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IProductRepository
    {
        Task<Product> addNewProduct(Product product);

        Task<IEnumerable<Product>> getProducts(IEnumerable<string>? categories, string? name, int? minPrice, int? maxPrice);

    }
}
