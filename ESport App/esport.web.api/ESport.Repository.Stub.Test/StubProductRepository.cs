using ESport.Data.Entities;
using System.Collections.Generic;

namespace ESport.Repository.Stub.Test
{
    public class StubProductRepository : IProductRepository
    {
        Product currentProduct;


        public void AddEntity(Product entity)
        {
            if (currentProduct != null && currentProduct.Equals(entity))
            {
                throw new RepositoryException("El producto ya existe");
            }
            else
            {
                currentProduct = entity;
            }
        }

        public void AddFieldInProduct(ProductFields productField)
        {
            currentProduct.Fields.Add(productField);
        }

        public void AddImageInProduct(ProductImage productImage)
        {
            currentProduct.Images.Add(productImage);
        }

        public List<Product> GetAllActiveProducts()
        {
            List<Product> result = new List<Product>();
            if (currentProduct != null && !currentProduct.Eliminated)
            {
                result.Add(currentProduct);
            }
            return result;
        }

        public List<Product> GetAllEntities()
        {
            List<Product> result = new List<Product>();
            if (currentProduct != null)
            {
                result.Add(currentProduct);
            }
            return result;
        }

        public List<Product> GetAllProductsByCategoryId(string categoryId)
        {
            List<Product> result = new List<Product>();
            if (currentProduct != null && currentProduct.Category != null && currentProduct.Category.CategoryId.Equals(categoryId))
            {
                result.Add(currentProduct);
            }
            return result;
        }

        public List<Field> GetNotUseFieldsByProdyct(Product product)
        {
            return new List<Field>();
        }

        public Product GetProductById(string productId)
        {
            if (currentProduct != null && currentProduct.ProductId.Equals(productId))
            {
                return currentProduct;
            }
            else
            {
                throw new RepositoryException("El producto no existe");
            }
        }

        public List<Product> GetProductsByFIlters(List<Filter> filters)
        {
            List<Product> result = new List<Product>();
            result.Add(currentProduct);
            return result;
        }

        public void RemoveEntity(Product entity)
        {
            currentProduct.Eliminated = true;
        }

        public void RemoveFieldFromProduct(ProductFields productField)
        {
            currentProduct.Fields.Remove(productField);
        }

        public void RemoveImageFromProduct(ProductImage productImage)
        {
            currentProduct.Images.Remove(productImage);
        }

        public void UpdateEntity(Product entity)
        {
            currentProduct = entity;
        }

        public void UpdateProductField(ProductFields productField)
        {
            currentProduct.Fields.Remove(productField);
            currentProduct.Fields.Add(productField);
        }
    }
}
