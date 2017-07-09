using ESport.Data.Commons;
using System.Collections.Generic;

namespace ESport.Data.Entities
{
    public interface ICategoryManager
    {
        void AddCategory(CategoryRequest request);
        void EditCategory(CategoryRequest request);
        void RemoveCategory(CategoryRequest request);
        List<Category> GetAllCategories();
        List<Category> GetAllActiveCategories();
        Category GetCategoryById(string categoryId);
        void AddProductOnCategory(CategoryRequest request);
        void RemoveProductFromCategory(CategoryRequest request);
    }
}
