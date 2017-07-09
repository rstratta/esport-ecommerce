using ESport.Data.Commons;
using ESport.Data.Entities;
using System;
using System.Collections.Generic;

namespace ESport.Data.Service
{
    public class CategoryServiceImpl : ICategoryService
    {
        private ICategoryManager categoryManager;
        private IDTOBuilder<CategoryDTO, Category> categoryBuilderDTO;

        public CategoryServiceImpl(ICategoryManager categoryManager, IDTOBuilder<CategoryDTO, Category> categoryBuilderDTO)
        {
            this.categoryManager = categoryManager;
            this.categoryBuilderDTO = categoryBuilderDTO;
        }

        public void AddCategory(CategoryRequest request)
        {
            ValidateRequest(request);
            categoryManager.AddCategory(request);
        }

        public void ValidateRequest(CategoryRequest request)
        {
            ValidateCategoryId(request.CategoryId);
            ValidateCategoryDescription(request.Description);
        }

        private void ValidateCategoryId(string categoryId)
        {
            if (String.IsNullOrWhiteSpace(categoryId))
            {
                throw new BadRequestException("El id de categoría es obligatorio para la operación");
            }
        }

        private void ValidateCategoryDescription(string description)
        {
            if (String.IsNullOrWhiteSpace(description))
            {
                throw new BadRequestException("La descripción de la categoría es obligatoria para la operación");
            }
        }

        public void EditCategory(CategoryRequest request)
        {
            ValidateRequest(request);
            categoryManager.EditCategory(request);
        }

        public void RemoveCategory(CategoryRequest request)
        {
            ValidateCategoryId(request.CategoryId);
            categoryManager.RemoveCategory(request);
        }

        public void AddProductOnCategory(CategoryRequest request)
        {
            ValidateCategoryId(request.CategoryId);
            ValidateProductId(request.ProductId);
            categoryManager.AddProductOnCategory(request);
        }

        public void RemoveProductFromCategory(CategoryRequest request)
        {
            ValidateCategoryId(request.CategoryId);
            ValidateProductId(request.ProductId);
            categoryManager.RemoveProductFromCategory(request);
        }

        private void ValidateProductId(string productId)
        {
            if (String.IsNullOrWhiteSpace(productId))
            {
                throw new BadRequestException("El id de producto es obligatorio para la operación");
            }
        }

        public List<CategoryDTO> GetAllCategories()
        {
            List<Category> allCategories = categoryManager.GetAllCategories();
            return BuildCategoryListDTO(allCategories);
        }

        private List<CategoryDTO> BuildCategoryListDTO(List<Category> allCategories)
        {
            List<CategoryDTO> result = new List<CategoryDTO>();
            foreach (Category category in allCategories)
            {
                result.Add(BuildCategoryDTO(category));
            }
            return result;
        }

        public List<CategoryDTO> GetAllActiveCategories()
        {
            List<Category> categories = categoryManager.GetAllActiveCategories();
            return BuildCategoryListDTO(categories);
        }

        public List<FullProductDTO> GetProductsByCategoryId(CategoryRequest request)
        {
            ValidateCategoryId(request.CategoryId);
            Category result = categoryManager.GetCategoryById(request.CategoryId);
            CategoryDTO dto =BuildCategoryDTO(result);
            return dto.Products;
        }

        private CategoryDTO BuildCategoryDTO(Category category)
        {
            return categoryBuilderDTO.buildDTO(category);
        }

        
    }
}
