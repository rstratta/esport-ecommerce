using ESport.Data.Commons;
using ESport.Data.Entities;

namespace ESport.Data.Service
{
    public class RoleDTOBuilder : IDTOBuilder<RoleDTO, Role>
    {
        public RoleDTO buildDTO(Role entity)
        {
            RoleDTO dto = new RoleDTO();
            dto.RoleId = entity.RoleId;
            dto.Description = entity.Description;
            dto.Eliminated = entity.Eliminated;
            return dto;
        }
    }
}
