using System.Collections.Generic;
using ESport.Data.Entities;

namespace ESport.Data.Entities
{
    public interface ICategoryRepository : IRepository<Category>
    {
        List<Category> GetAllActiveCategories();
        Category GetCategoryById(string categoryId);
        void RemoveProductFromCategory(Category currentCategory, Product productToRemove);
        void AddProductOnCategory(Category currentCategory, Product productToAdd);
    }
}
