using ESport.Data.Commons;
using System.Collections.Generic;

namespace ESport.Data.Entities
{
    public class RoleManager : IRoleManager
    {
        private IRoleRepository roleRepository;

        public RoleManager(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public void AddRole(RoleRequest roleRequest)
        {
            try
            {
                roleRepository.AddEntity(buildRoleFromRequest(roleRequest));
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }

        public void UpdateRole(RoleRequest roleRequest)
        {
            try
            {
                Role roleToEdit = roleRepository.GetRoleById(roleRequest.RoleId);
                roleToEdit.Description = roleRequest.Description;
                roleToEdit.Eliminated = false;
                roleRepository.UpdateEntity(roleToEdit);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }

        public List<Role> GetAllActiveRoles()
        {
            try
            {
                return roleRepository.GetAllActiveRoles();
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }

        public List<Role> GetAllRoles()
        {
            try
            {
                return roleRepository.GetAllEntities();
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }

        public Role GetRoleById(string roleId)
        {
            try
            {
                return roleRepository.GetRoleById(roleId);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }

        public void RemoveRole(RoleRequest roleRequest)
        {
            try
            {
                Role roleToRemove = roleRepository.GetRoleById(roleRequest.RoleId);
                roleRepository.RemoveEntity(roleToRemove);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }

        private Role buildRoleFromRequest(RoleRequest roleRequest)
        {
            Role result = new Role();
            result.RoleId = roleRequest.RoleId;
            result.Description = roleRequest.Description;
            return result;
        }
    }
}
