using entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        IceShopContext dbContext = new IceShopContext();

        public ProductRepository(IceShopContext DBContext)
        {
            this.dbContext = DBContext;
        }
        public async Task<Product> addNewProduct(Product product)
        {
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> getProducts(int[]? categryIds, int? minPrice, int? maxPrice, string? productName, string? description)
        {
            var products = await dbContext.Products.Include(product=>product.Category).ToListAsync();
            return products;
        }
    }
}
