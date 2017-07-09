using ESport.Data.Commons;
using ESport.Data.Entities;
using System;
using System.Collections.Generic;

namespace ESport.Data.Service
{
    public class ProductServiceImpl : IProductService
    {
        private IProductManager productManager;
        private IDTOBuilder<SimpleProductDTO, Product> simpleProductDTOBuilder;
        private IDTOBuilder<FullProductDTO, Product> fullProductDTOBuilder;
        public ProductServiceImpl(IProductManager productManager, IDTOBuilder<SimpleProductDTO, Product> simpleProductDTOBuilder, IDTOBuilder<FullProductDTO, Product> fullProductDTOBuilder)
        {
            this.productManager = productManager;
            this.simpleProductDTOBuilder = simpleProductDTOBuilder;
            this.fullProductDTOBuilder = fullProductDTOBuilder;
        }
        public void AddProduct(ProductRequest request)
        {
            ValidateRequest(request);
            productManager.AddProduct(request);
        }

        public void ValidateRequest(ProductRequest request)
        {
            ValidateProductId(request.ProductId);
            ValidateProductName(request.ProductName);
            ValidateProductDescription(request.Description);
            ValidatePrudctPrice(request.Price);
        }

        private void ValidateProductName(string productName)
        {
            if (String.IsNullOrWhiteSpace(productName))
            {
                throw new BadRequestException("El nombre de producto es obligatorio para la operación");
            }
        }

        private void ValidatePrudctPrice(double price)
        {
            if (price<=0)
            {
                throw new BadRequestException("El precio producto debe ser mayor a 0");
            }
        }

        private void ValidateProductDescription(string description)
        {
            if (String.IsNullOrWhiteSpace(description))
            {
                throw new BadRequestException("La descripcion de producto es obligatoria para la operación");
            }
        }

        private void ValidateProductId(string productId)
        {
            if (String.IsNullOrWhiteSpace(productId))
            {
                throw new BadRequestException("El id de producto es obligatorio para la operación");
            }
        }

        public void UpdateProduct(ProductRequest request)
        {
            ValidateRequest(request);
            productManager.EditProduct(request);
        }

        public void RemoveProduct(ProductRequest request)
        {
            ValidateProductId(request.ProductId);
            productManager.RemoveProduct(request);
        }

        public List<SimpleProductDTO> GetAllSimpleProducts()
        {
            List<Product> allProducts = productManager.GetAllActiveProducts();
            return BuildSimpleProductDTOList(allProducts);
        }

        private List<SimpleProductDTO> BuildSimpleProductDTOList(List<Product> allProducts)
        {
            List<SimpleProductDTO> result = new List<SimpleProductDTO>();
            foreach (Product product in allProducts)
            {
                result.Add(simpleProductDTOBuilder.buildDTO(product));
            }
            return result;
        }

        public List<FullProductDTO> GetAllFullProducts()
        {
            List<Product> allProducts = productManager.GetAllProducts();
            return BuildFullProductListDTO(allProducts);
        }

        private List<FullProductDTO> BuildFullProductListDTO(List<Product> allProducts)
        {
            List<FullProductDTO> result = new List<FullProductDTO>();
            foreach (Product product in allProducts)
            {
                List<Field> notUseFields=productManager.GetNotUseFieldByProduct(product);
                UpdateNotUsedFieldsOnProduct(notUseFields, product);
                result.Add(fullProductDTOBuilder.buildDTO(product));
            }
            return result;
        }

        private void UpdateNotUsedFieldsOnProduct(List<Field> notUseFields, Product product)
        {
            foreach (Field field in notUseFields)
            {
                product.Fields.Add(new ProductFields(product, field, null));
            }
        }

        public List<FullProductDTO> GetAllActiveFullProducts()
        {
            List<Product> allProducts = productManager.GetAllActiveProducts();
            return BuildFullProductListDTO(allProducts);
        }

        public void AddFieldOnProduct(ProductRequest request)
        {
            ValidateProductId(request.ProductId);
            ValidateMandatoryFieldRequest(request);
            ValidateFieldType(request.FieldType);
            productManager.AddFieldOnProduct(request);
        }

        private void ValidateFieldType(string fieldType)
        {
            if (String.IsNullOrWhiteSpace(fieldType))
            {
                throw new BadRequestException("El tipo de campo es obligatorio para esta operación");
            }
        }

        private void ValidateMandatoryFieldRequest(ProductRequest request)
        {
            ValidateFieldName(request.FieldName);
            ValidateFieldValue(request.FieldValue);
        }

        private void ValidateFieldName(string fieldName)
        {
            if (String.IsNullOrWhiteSpace(fieldName))
            {
                throw new BadRequestException("El nombre del campo es obligatorio");
            }
        }

        private void ValidateFieldValue(string fieldValue)
        {
            if (String.IsNullOrWhiteSpace(fieldValue))
            {
                throw new BadRequestException("El valor del campo es obligatorio para esta operación");
            }
        }

        public void EditFieldOnProduct(ProductRequest request)
        {
            ValidateProductId(request.ProductId);
            ValidateMandatoryFieldRequest(request);
            productManager.ModifyFieldOnProduct(request);
        }

        public void RemoveFieldOnProduct(ProductRequest request)
        {
            ValidateProductId(request.ProductId);
            ValidateFieldName(request.FieldName);
            productManager.DeleteFieldOnProduct(request);
        }

        public List<FullProductDTO> GetProductsByFilters(ProductRequest productRequest)
        {
            List<Product> allProducts = productManager.GetSimpleProductsByFilters(productRequest);
            return BuildFullProductListDTO(allProducts);
        }

        public void AddProductInBlackList(ProductRequest request)
        {
            ValidateProductId(request.ProductId);
            productManager.AddProductInBlackList(request);
        }

        public void RemoveProductFromBlackList(ProductRequest request)
        {
            ValidateProductId(request.ProductId);
            productManager.RemoveProductFromBlackList(request);
        }

        public void UpdateStockProduct(ProductRequest request)
        {
            ValidateProductId(request.ProductId);
            ValidateAvailableStock(request.AvailableStock);
            productManager.UpdateStockProduct(request);
            
        }

        private void ValidateAvailableStock(int availableStock)
        {
            if (availableStock < 0)
            {
                throw new BadRequestException("El stock debe ser mayor a 0");
            }
        }

        public void SimpleUpdateProduct(ProductRequest request)
        {
            ValidateRequest(request);
            productManager.SimpleUpdateProduct(request);
        }
    }
}
