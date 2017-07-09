using ESport.Data.Commons;
using ESport.Data.Entities;
using System.Collections.Generic;

namespace ESport.Data.Service
{
    public class UserDTOBuilder : IDTOBuilder<UserDTO, User>
    {
        public UserDTO buildDTO(User entity)
        {
            UserDTO dto = new UserDTO();
            dto.UserId = entity.UserId;
            dto.UserName = entity.UserName;
            dto.UserLastName = entity.UserLastName;
            dto.Address = entity.Address;
            dto.EMail = entity.EMail;
            dto.Phone = entity.Phone;
            dto.Eliminated = entity.Eliminated;
            dto.Points = entity.Points;
            if(entity.Roles!=null)
                dto.Roles = GetRolesFromUser(entity);
            return dto;
        }

        private List<RoleDTO> GetRolesFromUser(User entity)
        {
            IDTOBuilder<RoleDTO, Role> roleDTOBuilder = new RoleDTOBuilder();
            List<RoleDTO> roles = new List<RoleDTO>();
            foreach (Role role in entity.Roles)
            {
                if(!role.Eliminated)
                    roles.Add(roleDTOBuilder.buildDTO(role));
            }
            return roles;
        }
    }
}
