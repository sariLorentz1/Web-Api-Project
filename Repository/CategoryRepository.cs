using entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        IceShopContext dbContext = new IceShopContext();

        public CategoryRepository(IceShopContext DBContext)
        {
            this.dbContext = DBContext;
        }
        public async Task<Category> addNewCategory(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
            return category;

        }

        public async Task<IEnumerable<Category>> getCategories()
        {
            var categories = await dbContext.Categories.ToListAsync();
            return categories;
        }

    }
}
