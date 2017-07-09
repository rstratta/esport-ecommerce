using ESport.Data.Commons;
using System.Collections.Generic;

namespace ESport.Data.Service
{
    public interface IProductService : IService<ProductRequest>
    {
        void AddProduct(ProductRequest request);
        void UpdateProduct(ProductRequest request);
        void RemoveProduct(ProductRequest request);
        List<SimpleProductDTO> GetAllSimpleProducts();
        List<FullProductDTO> GetAllFullProducts();
        List<FullProductDTO> GetAllActiveFullProducts();
        void AddFieldOnProduct(ProductRequest request);
        void EditFieldOnProduct(ProductRequest request);
        void RemoveFieldOnProduct(ProductRequest request);
        List<FullProductDTO> GetProductsByFilters(ProductRequest productRequest);
        void AddProductInBlackList(ProductRequest productRequest);
        void RemoveProductFromBlackList(ProductRequest productRequest);
        void UpdateStockProduct(ProductRequest request);
        void SimpleUpdateProduct(ProductRequest request);
    }
}
