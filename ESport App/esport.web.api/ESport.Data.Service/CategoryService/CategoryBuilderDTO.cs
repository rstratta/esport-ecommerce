using System.Collections.Generic;

using ESport.Data.Commons;
using ESport.Data.Entities;

namespace ESport.Data.Service
{
    public class CategoryBuilderDTO : IDTOBuilder<CategoryDTO, Category>
    {
        private IDTOBuilder<FullProductDTO, Product> productDTOBuilder;

        public CategoryBuilderDTO(IDTOBuilder<FullProductDTO, Product> productDTOBuilder)
        {
            this.productDTOBuilder = productDTOBuilder;
        }
        public CategoryDTO buildDTO(Category entity)
        {
            CategoryDTO dto = new CategoryDTO();
            dto.CategoryId = entity.CategoryId;
            dto.Description = entity.Description;
            dto.Eliminated = entity.Eliminated;
            if(entity.Products != null)
                dto.Products = BuildProductListDTO(entity.Products);
            return dto;
        }

        private List<FullProductDTO> BuildProductListDTO(ICollection<Product> products)
        {
            List<FullProductDTO> result = new List<FullProductDTO>();
            foreach (Product product in products)
            {
                result.Add(productDTOBuilder.buildDTO(product));
            }
            return result;
        }
    }
}
