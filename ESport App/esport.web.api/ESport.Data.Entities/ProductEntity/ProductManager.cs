using ESport.Data.Commons;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ESport.Data.Entities
{
    public class ProductManager : IProductManager
    {
        private IProductRepository productRepository;
        private IFieldRepository fieldRepository;
        public ProductManager(IProductRepository productRepository, IFieldRepository fieldRepository)
        {
            this.productRepository = productRepository;
            this.fieldRepository = fieldRepository;
        }
        public void AddProduct(ProductRequest request)
        {
            try
            {
                Product productToAdd = BuildProductFromRequest(request);
                productToAdd.AvailableStock = request.AvailableStock;
                productRepository.AddEntity(productToAdd);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message, e);
            }
        }
        private Product BuildProductFromRequest(ProductRequest request)
        {
            Product product = new Product(request.ProductId, request.ProductName, request.Description, request.Price, request.Factory);
            product.Images = GetImagesFromRequest(request);
            return product;
        }

        private List<ProductImage> GetImagesFromRequest(ProductRequest request)
        {
            List<ProductImage> images = new List<ProductImage>();
            foreach (var image in request.Images)
            {
                images.Add(new ProductImage(image.Id, image.Content));
            }
            return images;
        }

        public void EditProduct(ProductRequest request)
        {
            try
            {
                SimpleUpdateProduct(request);
                UpdateProductImages(GetProductById(request.ProductId), request);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message, e);
            }
        }

        public void SimpleUpdateProduct(ProductRequest request)
        {
            try { 
                Product currentProduct = GetProductById(request.ProductId);
                currentProduct.Description = request.Description;
                currentProduct.Factory = request.Factory;
                currentProduct.Price = request.Price;
                currentProduct.Eliminated = false;
                currentProduct.ProductName = request.ProductName;
                productRepository.UpdateEntity(currentProduct);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message, e);
            }
        }

        private void UpdateProductImages(Product currentProduct, ProductRequest request)
        {
            List<ProductImage> imageRequest = GetImagesFromRequest(request);
            RemoveImages(currentProduct.Images);
            foreach (var image in imageRequest)
            {
                image.Product = currentProduct;
                productRepository.AddImageInProduct(image);
            }

        }

        private void RemoveImages(ICollection<ProductImage> imagesToRemove)
        {
            ICollection<ProductImage> images = new List<ProductImage>();
            foreach (var image in imagesToRemove)
            {
                images.Add(image);
            }
            foreach (var image in images)
            {
                productRepository.RemoveImageFromProduct(image);
            }

        }

        public List<Product> GetAllActiveProducts()
        {
            try
            {
                return productRepository.GetAllActiveProducts();
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message, e);
            }
        }
        public List<Product> GetAllProducts()
        {
            try
            {
                return productRepository.GetAllEntities();
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message, e);
            }
        }
        public Product GetProductById(string productId)
        {
            try
            {
                return productRepository.GetProductById(productId);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message, e);
            }
        }
        public void RemoveProduct(ProductRequest request)
        {
            try
            {
                Product currentProduct = GetProductById(request.ProductId);
                productRepository.RemoveEntity(currentProduct);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message, e);
            }
        }
        public void AddFieldOnProduct(ProductRequest request)
        {
            try
            {
                Product currentProduct = productRepository.GetProductById(request.ProductId);
                Field field = GetFieldFromRequest(request);
                if (!ExistsField(currentProduct, field))
                {
                    productRepository.AddFieldInProduct(BuildProductField(currentProduct, field, request));
                }
                else
                {
                    throw new OperationException("Ya existe este campo en este producto");
                }
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message, e);
            }
        }

        private ProductFields BuildProductField(Product currentProduct, Field field, ProductRequest request)
        {
            return new ProductFields(currentProduct, field, request.FieldValue);
        }

        private bool ExistsField(Product product, Field field)
        {
            if (product.Fields.Count == 0)
            {
                return false;
            }
            else
            {
                foreach (ProductFields productField in product.Fields)
                {
                    if (productField.FieldId.Equals(field.Id))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        private Field GetFieldFromRequest(ProductRequest request)
        {
            Field result;
            try
            {
                result = fieldRepository.GetFieldByName(request.FieldName);
            }
            catch (RepositoryException)
            {
                result = new Field();
                result.Name = request.FieldName;
                result.Type = request.FieldType;
                fieldRepository.AddEntity(result);
            }
            return result;
        }
        public void DeleteFieldOnProduct(ProductRequest request)
        {
            try
            {
                Product currentProduct = productRepository.GetProductById(request.ProductId);
                Field field = fieldRepository.GetFieldByName(request.FieldName);
                if (currentProduct.Fields.Count == 0)
                {
                    throw new OperationException("El producto no tiene campos para eliminar");
                }
                else if (!ExistsField(currentProduct, field))
                {
                    throw new OperationException("No existe el campo que desea eliminar");
                }
                else
                {
                    ProductFields prodFieldToRemove = currentProduct.Fields.Where(f => f.FieldId == field.Id).First();
                    productRepository.RemoveFieldFromProduct(prodFieldToRemove);
                }
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message, e);
            }
            catch (Exception e)
            {
                throw new OperationException("Error al procesar operación", e);
            }
        }
        public void ModifyFieldOnProduct(ProductRequest request)
        {
            try
            {
                Product currentProduct = productRepository.GetProductById(request.ProductId);
                foreach (ProductFields productField in currentProduct.Fields)
                {
                    if (productField.Field.Name.Equals(request.FieldName))
                    {
                        productField.Value = request.FieldValue;
                        productRepository.UpdateProductField(productField);
                        return;
                    }
                }
                throw new OperationException("No existe el campo que desea modificar");
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message, e);
            }
        }

        public List<Product> GetSimpleProductsByFilters(ProductRequest productRequest)
        {
            return productRepository.GetProductsByFIlters(GetFilters(productRequest.Filters));
        }

        private List<Filter> GetFilters(List<FieldDTO> filters)
        {
            List<Filter> result = new List<Filter>();
            if (filters != null)
                foreach (FieldDTO dto in filters)
                {
                    result.Add(new Filter() { FilterName = dto.FieldName, FilterValue = dto.FieldValue });
                }
            return result;
        }

        public List<Field> GetNotUseFieldByProduct(Product product)
        {
            try
            {
                return productRepository.GetNotUseFieldsByProdyct(product);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message, e);
            }
        }

        public void AddProductInBlackList(ProductRequest request)
        {
            try
            {
                Product currentProduct = productRepository.GetProductById(request.ProductId);
                currentProduct.BlackProduct = true;
                productRepository.UpdateEntity(currentProduct);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message, e);
            }
        }

        public void RemoveProductFromBlackList(ProductRequest request)
        {
            try
            {
                Product currentProduct = productRepository.GetProductById(request.ProductId);
                currentProduct.BlackProduct = false;
                productRepository.UpdateEntity(currentProduct);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message, e);
            }
        }

        public void UpdateStockProduct(ProductRequest request)
        {
            try { 
                Product currentProduct = GetProductById(request.ProductId);
                currentProduct.AvailableStock = request.AvailableStock;
                productRepository.UpdateEntity(currentProduct);
            }catch(RepositoryException e)
            {
                throw new OperationException(e.Message, e);
            }
        }
    }
}
