using ESport.Data.Commons;
using System.Collections.Generic;

namespace ESport.Data.Service
{
    public interface IRoleService : IService<RoleRequest>
    {
        void AddRole(RoleRequest request);
        void UpdateRole(RoleRequest roleRequest);
        void RemoveRole(RoleRequest roleRequest);
        RoleDTO GetRoleById(RoleRequest roleRequest);

        List<RoleDTO> GetAllRoles();
        List<RoleDTO> GetAllActiveRoles();
    }
}
