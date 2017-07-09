using ESport.Data.Commons;
using ESport.Data.Entities;

namespace ESport.Data.Service
{
    public class ImageDTOBuilder : IDTOBuilder<ProductImageDTO, ProductImage>
    {
        public ProductImageDTO buildDTO(ProductImage entity)
        {
            return new ProductImageDTO(entity.Id, entity.Base64EncodedImage);
        }
    }
}
