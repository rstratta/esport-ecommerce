using ESport.Data.Commons;
using ESport.Data.Entities;
using System.Collections.Generic;

namespace ESport.Data.Service
{
    public class FullProductDTOBuilder : IDTOBuilder<FullProductDTO, Product>
    {
        IDTOBuilder<FieldDTO, ProductFields> fieldDTOBuilder;
        IDTOBuilder<ProductImageDTO, ProductImage> imageDTOBuilder;

        public FullProductDTOBuilder(IDTOBuilder<FieldDTO, ProductFields> fieldDTOBuilder, IDTOBuilder<ProductImageDTO, ProductImage> imageDTOBuilder)
        {
            this.fieldDTOBuilder = fieldDTOBuilder;
            this.imageDTOBuilder = imageDTOBuilder;
        }
        public FullProductDTO buildDTO(Product entity)
        {
            FullProductDTO dto = new FullProductDTO();
            dto.ProductName = entity.ProductName;
            dto.ProductId = entity.ProductId;
            dto.Description = entity.Description;
            dto.Price = entity.Price;
            dto.ReviewAverage = entity.ReviewAverage;
            dto.Eliminated = entity.Eliminated;
            dto.Images = GetImagesDTO(entity.Images);
            dto.Factory = entity.Factory;
            dto.Fields = BuildFieldsDTOList(entity.Fields);
            dto.BlackProduct = entity.BlackProduct;
            dto.AvailableStock = entity.AvailableStock;
            if (entity.Category != null) { 
                dto.CategoryId = entity.Category.CategoryId;
            }
            return dto;
        }

        private List<ProductImageDTO> GetImagesDTO(ICollection<ProductImage> images)
        {
            List<ProductImageDTO> imagesDTO = new List<ProductImageDTO>();
            foreach (ProductImage image in images)
            {
                imagesDTO.Add(imageDTOBuilder.buildDTO(image));
            }
            return imagesDTO;
        }

        private List<FieldDTO> BuildFieldsDTOList(ICollection<ProductFields> fields)
        {
            List<FieldDTO> result = new List<FieldDTO>();
            foreach (ProductFields field in fields)
            {
                result.Add(fieldDTOBuilder.buildDTO(field));
            }
            return result;
        }
    }
}
