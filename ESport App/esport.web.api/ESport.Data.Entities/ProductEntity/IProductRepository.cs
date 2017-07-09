using System.Collections.Generic;
using ESport.Data.Commons;

namespace ESport.Data.Entities
{
    public interface IProductRepository : IRepository<Product>
    {

        List<Product> GetAllActiveProducts();
        Product GetProductById(string productId);
        List<Product> GetAllProductsByCategoryId(string categoryId);

        void RemoveFieldFromProduct(ProductFields productField);

        void AddFieldInProduct(ProductFields productField);
        void UpdateProductField(ProductFields productField);
        List<Product> GetProductsByFIlters(List<Filter> filters);

        void RemoveImageFromProduct(ProductImage productImage);

        void AddImageInProduct(ProductImage productImage);
        List<Field> GetNotUseFieldsByProdyct(Product product);
    }
}
