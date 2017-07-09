using ESport.Data.Commons;
using System.Collections.Generic;

namespace ESport.Data.Entities
{
    public interface IProductManager
    {
        void AddProduct(ProductRequest request);
        void EditProduct(ProductRequest request);
        void RemoveProduct(ProductRequest request);
        List<Product> GetAllProducts();
        List<Product> GetAllActiveProducts();
        Product GetProductById(string productId);
        void AddFieldOnProduct(ProductRequest request);
        void DeleteFieldOnProduct(ProductRequest request);
        void ModifyFieldOnProduct(ProductRequest request);
        List<Product> GetSimpleProductsByFilters(ProductRequest productRequest);
        List<Field> GetNotUseFieldByProduct(Product product);
        void AddProductInBlackList(ProductRequest request);
        void RemoveProductFromBlackList(ProductRequest request);
        void UpdateStockProduct(ProductRequest request);
        void SimpleUpdateProduct(ProductRequest request);

    }
}
