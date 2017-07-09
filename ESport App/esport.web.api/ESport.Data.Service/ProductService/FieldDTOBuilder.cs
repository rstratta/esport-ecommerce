using ESport.Data.Commons;
using ESport.Data.Entities;

namespace ESport.Data.Service
{
    public class FieldDTOBuilder : IDTOBuilder<FieldDTO, ProductFields>
    {
        public FieldDTO buildDTO(ProductFields entity)
        {
            FieldDTO dto = new FieldDTO();
            dto.FieldName = entity.Field.Name;
            dto.FieldValue = entity.Value;
            dto.FieldType = entity.Field.Type;
            return dto;
        }
    }
}
