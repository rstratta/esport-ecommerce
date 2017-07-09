using ESport.Data.Commons;
using System.Collections.Generic;

namespace ESport.Data.Entities
{
    public interface IRoleManager
        {
            void AddRole(RoleRequest roleRequest);
            void UpdateRole(RoleRequest roleRequest);
            void RemoveRole(RoleRequest roleRequest);
            List<Role> GetAllRoles();
            List<Role> GetAllActiveRoles();
            Role GetRoleById(string roleId);
        }
    }