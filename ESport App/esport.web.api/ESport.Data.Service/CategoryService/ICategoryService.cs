using ESport.Data.Commons;
using System.Collections.Generic;

namespace ESport.Data.Service
{
    public interface ICategoryService : IService<CategoryRequest>
    {
        void AddCategory(CategoryRequest request);
        void EditCategory(CategoryRequest request);
        void RemoveCategory(CategoryRequest request);
        void AddProductOnCategory(CategoryRequest request);
        List<CategoryDTO> GetAllCategories();
        List<CategoryDTO> GetAllActiveCategories();
        List<FullProductDTO> GetProductsByCategoryId(CategoryRequest request);
        void RemoveProductFromCategory(CategoryRequest categoryRequest);
    }
}
