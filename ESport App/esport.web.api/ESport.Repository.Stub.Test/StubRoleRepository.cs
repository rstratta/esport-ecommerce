using ESport.Data.Entities;
using System.Collections.Generic;

namespace ESport.Repository.Stub.Test
{
    public class StubRoleRepository : IRoleRepository
    {
        Role currentRole;
        public void AddEntity(Role entity)
        {
            if (currentRole != null && currentRole.Equals(entity))
            {
                throw new RepositoryException("El rol ya existe");
            }
            else
            {
                currentRole = entity;
            }
        }

        public List<Role> GetAllActiveRoles()
        {
            List<Role> result = new List<Role>();
            if (currentRole != null && !currentRole.Eliminated)
            {
                result.Add(currentRole);
            }
            return result;
        }

        public List<Role> GetAllEntities()
        {
            List<Role> result = new List<Role>();
            if (currentRole != null)
            {
                result.Add(currentRole);
            }
            return result;
        }

        public Role GetRoleById(string roleId)
        {
            if (currentRole != null && currentRole.RoleId.Equals(roleId))
            {
                return currentRole;
            }
            else
            {
                throw new RepositoryException("No existe Role");
            }
        }

        public void RemoveEntity(Role entity)
        {
            currentRole.Eliminated = true;
        }

        public void UpdateEntity(Role entity)
        {
            currentRole = entity;
        }
    }
}
