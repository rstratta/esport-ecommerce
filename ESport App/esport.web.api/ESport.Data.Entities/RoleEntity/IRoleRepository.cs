using System.Collections.Generic;

namespace ESport.Data.Entities
{
    public interface IRoleRepository : IRepository<Role>
    {
        Role GetRoleById(string roleId);
        List<Role> GetAllActiveRoles();
    }
}
