using ESport.Data.Entities;
using System.Collections.Generic;

namespace ESport.Repository.Stub.Test
{
    public class StubCategoryRepository : ICategoryRepository

    {
        Category currentCategory;


        public void AddEntity(Category entity)
        {
            if (currentCategory != null && currentCategory.Equals(entity))
            {
                throw new RepositoryException("La categoría ya existe");
            }
            else
            {
                currentCategory = entity;
            }
        }

        public void AddProductOnCategory(Category currentCategory, Product productToAdd)
        {
            currentCategory.AddProduct(productToAdd);
            this.currentCategory = currentCategory;
        }

        public List<Category> GetAllActiveCategories()
        {
            List<Category> result = new List<Category>();
            if (currentCategory != null && !currentCategory.Eliminated)
            {
                result.Add(currentCategory);
            }
            return result;
        }

        public List<Category> GetAllEntities()
        {
            List<Category> result = new List<Category>();
            if (currentCategory != null)
            {
                result.Add(currentCategory);
            }
            return result;
        }

        public Category GetCategoryById(string categoryId)
        {
            if (currentCategory != null && currentCategory.CategoryId.Equals(categoryId))
            {
                return currentCategory;
            }
            else
            {
                throw new RepositoryException("La categoría no existe");
            }
        }

        public void RemoveEntity(Category entity)
        {
            currentCategory.Eliminated = true;
        }

        public void RemoveProductFromCategory(Category currentCategory, Product productToRemove)
        {
            currentCategory.Products.Remove(productToRemove);
            this.currentCategory = currentCategory;
        }

        public void UpdateEntity(Category entity)
        {
            currentCategory = entity;
        }
    }

}
