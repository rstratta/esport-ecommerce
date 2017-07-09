using ESport.Data.Commons;
using ESport.Data.Entities;
using System.Collections.Generic;

namespace ESport.Data.Service
{
    public class SimpleProductDTOBuilder : IDTOBuilder<SimpleProductDTO, Product>
    {
        IDTOBuilder<ProductImageDTO, ProductImage> imageDTOBuilder;

        public SimpleProductDTOBuilder(IDTOBuilder<ProductImageDTO, ProductImage> imageDTOBuilder)
        {
            this.imageDTOBuilder = imageDTOBuilder;
        }
        public SimpleProductDTO buildDTO(Product entity)
        {
            SimpleProductDTO dto = new SimpleProductDTO();
            dto.ProductName = entity.ProductName;
            dto.ProductId = entity.ProductId;
            dto.Description = entity.Description;
            dto.Price = entity.Price;
            dto.Images = GetImagesDTO(entity);
            dto.Factory = entity.Factory;
            dto.BlackProduct = entity.BlackProduct;
            dto.AvailableStock = entity.AvailableStock;
            dto.ReviewAverage = entity.ReviewAverage;
            return dto;
        }
        private List<ProductImageDTO> GetImagesDTO(Product entity)
        {
            List<ProductImageDTO> imagesDTO = new List<ProductImageDTO>();
            try
            {
                foreach (ProductImage image in entity.Images)
                {
                    imagesDTO.Add(imageDTOBuilder.buildDTO(image));
                }
            }
            catch (System.ObjectDisposedException)
            {

            }
            return imagesDTO;
        }

    }
}
