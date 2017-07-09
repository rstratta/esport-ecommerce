using ESport.Data.Commons;
using ESport.Data.Entities;
using System;
using System.Collections.Generic;

namespace ESport.Data.Service
{
    public class RoleServiceImpl : IRoleService
    {
        private IRoleManager roleManager;
        private IDTOBuilder<RoleDTO, Role> dtoBuilder;

        public RoleServiceImpl(IRoleManager roleManager, IDTOBuilder<RoleDTO, Role> dtoBuilder)
        {
            this.roleManager = roleManager;
            this.dtoBuilder = dtoBuilder;
        }
        public void AddRole(RoleRequest request)
        {
            ValidateRequest(request);
            roleManager.AddRole(request);
        }

        public RoleDTO GetRoleById(RoleRequest roleRequest)
        {
            ValidateRoleId(roleRequest);
            return ConvertToDTO(roleManager.GetRoleById(roleRequest.RoleId));
        }


        public void UpdateRole(RoleRequest roleRequest)
        {
            ValidateRequest(roleRequest);
            roleManager.UpdateRole(roleRequest);
        }

        public void RemoveRole(RoleRequest roleRequest)
        {
            ValidateRoleId(roleRequest);
            roleManager.RemoveRole(roleRequest);
        }

        public void ValidateRequest(RoleRequest request)
        {
            ValidateRoleId(request);
            validateRoleDescription(request);
        }

        private void ValidateRoleId(RoleRequest request)
        {
            if (String.IsNullOrWhiteSpace(request.RoleId))
            {
                throw new BadRequestException("El Id del Rol no puede ser nulo");
            }
        }

        private void validateRoleDescription(RoleRequest request)
        {
            if (String.IsNullOrWhiteSpace(request.Description))
            {
                throw new BadRequestException("La descripción del Rol no puede ser nulo");
            }
        }

        public RoleDTO ConvertToDTO(Role entity)
        {
            return dtoBuilder.buildDTO(entity);
        }

        public List<RoleDTO> GetAllRoles()
        {
            List<Role> roles = roleManager.GetAllRoles();
            return ConvertToListDTO(roles);
        }

        private List<RoleDTO> ConvertToListDTO(List<Role> roles)
        {
            List<RoleDTO> result = new List<RoleDTO>();
            foreach (Role role in roles)
            {
                result.Add(ConvertToDTO(role));
            }
            return result;
        }

        public List<RoleDTO> GetAllActiveRoles()
        {
            List<Role> roles = roleManager.GetAllActiveRoles();
            return ConvertToListDTO(roles);
        }
    }
}
