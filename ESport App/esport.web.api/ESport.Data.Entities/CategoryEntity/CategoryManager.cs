using System.Collections.Generic;
using ESport.Data.Commons;

namespace ESport.Data.Entities
{
    public class CategoryManager : ICategoryManager
    {
        private ICategoryRepository categoryRepository;
        private IProductRepository productRepository;
        

        public CategoryManager(ICategoryRepository categoryRepository,IProductRepository productRepository)
        {
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
        }

     

        public void AddCategory(CategoryRequest request)
        {
            try
            { 
                categoryRepository.AddEntity(BuildCategoryFromRequest(request));
            }catch(RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }
        
        private Category BuildCategoryFromRequest(CategoryRequest request)
        {
            Category category = new Category(request.CategoryId, request.Description);
            return category;
        }

        public void EditCategory(CategoryRequest request)
        {
            try { 
                Category currentCategory = categoryRepository.GetCategoryById(request.CategoryId);
                currentCategory.Description = request.Description;
                currentCategory.Eliminated = false;
                categoryRepository.UpdateEntity(currentCategory);
            }catch(RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }

        public List<Category> GetAllActiveCategories()
        {
            return categoryRepository.GetAllActiveCategories();
        }

        public List<Category> GetAllCategories()
        {
            try { 
                return categoryRepository.GetAllEntities();
            }catch(RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }

        public Category GetCategoryById(string categoryId)
        {
            try { 
                return categoryRepository.GetCategoryById(categoryId);
            }catch(RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }

        public void RemoveCategory(CategoryRequest request)
        {
            try { 
                Category currentCategory = GetCategoryById(request.CategoryId);
                categoryRepository.RemoveEntity(currentCategory);
                RemoveProductsFromCategoryAfterDelete(currentCategory);
            }catch(RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }

        private void RemoveProductsFromCategoryAfterDelete(Category currentCategory)
        {
            foreach (Product prod in currentCategory.Products)
            {
                RemoveProductFromCategory(new CategoryRequest() { CategoryId = currentCategory.CategoryId, ProductId = prod.ProductId });
            }
        }

        public void AddProductOnCategory(CategoryRequest request)
        {
            try { 
                Product productToAdd = productRepository.GetProductById(request.ProductId);
                Category currentCategory = categoryRepository.GetCategoryById(request.CategoryId);
                if (productToAdd.Category!=null)
                {
                    throw new OperationException("El producto ya se encuentra asignado a una categoría");
                }
                categoryRepository.AddProductOnCategory(currentCategory, productToAdd);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }

        public void RemoveProductFromCategory(CategoryRequest request)
        {
            try
            {
                Product productToRemove = productRepository.GetProductById(request.ProductId);
                Category currentCategory = categoryRepository.GetCategoryById(request.CategoryId);
                if (productToRemove.Category==null || !productToRemove.Category.Equals(currentCategory))
                {
                    throw new OperationException("El producto no se encuentra asignado a la categoría");
                }
                categoryRepository.RemoveProductFromCategory(currentCategory, productToRemove);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }
    }
}

