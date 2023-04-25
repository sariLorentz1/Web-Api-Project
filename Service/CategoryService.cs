using entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CategoryService : ICategoryService
    {

        ICategoryRepository repository;
        public CategoryService(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Category> addNewCategory(Category category)
        {
            return await this.repository.addNewCategory(category);
        }

        public async Task<IEnumerable<Category>> getCategories()
        {
            return await this.repository.getCategories();
        }
    }
}
