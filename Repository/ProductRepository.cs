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


        public async Task<IEnumerable<Product>> getProducts(IEnumerable<string>? categories, string? name, int? minPrice, int? maxPrice)
        {
            int a=  0;
            int b = 3 / a;
            return await dbContext.Products.Include(p => p.Category).Where(p =>
            (categories.Count() <= 0 ? (true) : categories.Contains(p.CategoryId.ToString())) &&
            (name == null || p.Name.Contains(name)) &&
            (minPrice == null || p.Price >= minPrice) &&
            (maxPrice == null || p.Price <= maxPrice)).OrderBy(p => p.CategoryId).ToListAsync();
           
        }



        public async Task<Product> GetProductById(int id)
        {
            Product? product = await dbContext.Products.FindAsync(id);//.Include(p => p.Category);
            return product != null ? product : null;
        }
    }
}
