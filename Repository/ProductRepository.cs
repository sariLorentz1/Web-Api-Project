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
            var query = dbContext.Products.Where(product =>

                   (name == null ? (true) : product.Name.Contains(name))
                     &&
                    (minPrice == null ? (true) : product.Price > minPrice)
                    &&
                    (maxPrice == null ? (true) : product.Price < maxPrice)
             &&
             (categories.Count() <= 0 ? (true) : categories.Contains(product.CategoryId.ToString()))
             );/*.OrderBy(product => product.Price);*/

            return await query.ToListAsync();

            //return await dbContext.Products.ToListAsync();
        }

        //public async Task<IEnumerable<Product>> getProductsBySearch(string? desc, int? minPrice, int? maxPrice, IEnumerable<string>? categoryId)
        //{
        //    var query = _DbContext.Products.Where(product =>

        //        (desc == null ? (true) : product.Description.Contains(desc))
        //            &&
        //            (minPrice == null ? (true) : product.Price > minPrice)
        //            &&
        //            (maxPrice == null ? (true) : product.Price < maxPrice)
        //            &&
        //            (categoryId.Count() <= 0 ? (true) : categoryId.Contains(product.Category.Id.ToString()))
        //).OrderBy(product => product.Price);

        //    return await query.ToListAsync();

        //}
    }
}

