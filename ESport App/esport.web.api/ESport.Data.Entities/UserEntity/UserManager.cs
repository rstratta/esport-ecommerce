using ESport.Data.Commons;
using System.Collections.Generic;

namespace ESport.Data.Entities
{
    public class UserManager : IUserManager
    {
        private IUserRepository userRepository;
        private IRoleRepository roleRepository;

        public UserManager(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public void AddUser(UserRequest userRequest)
        {
            try
            {
                User userToAdd = buildUserFromRequest(userRequest);
                userToAdd.Password = userRequest.Password;
                userRepository.AddEntity(userToAdd);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }

        public void EditUser(UserRequest userRequest)
        {
            try
            {
                User user = userRepository.GetUserById(userRequest.UserId);
                userRequest.Eliminated = false;
                FillUser(user, userRequest);
                userRepository.UpdateEntity(user);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }

        public List<User> GetAllActiveUsers()
        {
            try
            {
                return userRepository.GetAllActiveUsers();
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }

        }

        public List<User> GetAllUsers()
        {
            try
            {
                return userRepository.GetAllEntities();
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }

        public User GetUserById(string userId)
        {
            try
            {
                return userRepository.GetUserById(userId);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }

        public void RemoveUser(UserRequest userRequest)
        {
            try
            {
                User userToRemove = userRepository.GetUserById(userRequest.UserId);
                userRepository.RemoveEntity(userToRemove);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }

        private User buildUserFromRequest(UserRequest userRequest)
        {
            User user = new User();
            FillUser(user, userRequest);
            user.Roles.Add(GetRoleByRoleId(userRequest.RoleId));
            return user;
        }

        private Role GetRoleByRoleId(string roleId)
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

        private void FillUser(User user, UserRequest userRequest)
        {
            user.UserId = userRequest.UserId;
            user.Address = userRequest.Address;
            user.EMail = userRequest.EMail;
            user.UserLastName = userRequest.UserLastName;
            user.UserName = userRequest.UserName;
            user.Eliminated = userRequest.Eliminated;
            user.Phone = userRequest.Phone;
            user.Roles = new HashSet<Role>();
        }

        public void AssignRole(UserRequest userRequest)
        {
            try
            {
                Role role = GetRoleByRoleId(userRequest.RoleId);
                User user = GetUserById(userRequest.UserId);
                userRepository.AddRoleInUser(user, role);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }

        private void AddRoleOnUser(User user, Role role)
        {
            if (!user.Roles.Contains(role))
            {
                AddRoleAndEditUser(user, role);
            }
            else
            {
                throw new OperationException("El rol ya se ha asignado a este usuario");
            }

        }

        private void AddRoleAndEditUser(User user, Role role)
        {
            try
            {
                user.Roles.Add(role);
                userRepository.UpdateEntity(user);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }

        public void UpdatePassword(UserRequest request)
        {
            try
            {
                User currentUser = userRepository.GetUserById(request.UserId);
                ValidateUserPassword(currentUser.Password, request.Password);
                ValidateNewPassword(currentUser.Password, request.NewPassword);
                currentUser.Password = request.NewPassword;
                userRepository.UpdateEntity(currentUser);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }

        private void ValidateUserPassword(string userPassword, string requestPassword)
        {
            if (!userPassword.Equals(requestPassword))
            {
                throw new OperationException("El password del usuario no coincide con el actual");
            }
        }

        private void ValidateNewPassword(string userPassword, string requestNewPassword)
        {
            if (userPassword.Equals(requestNewPassword))
            {
                throw new OperationException("El nuevo password debe ser diferente al actual");
            }
        }

        public void RemoveRoleFromUser(UserRequest userRequest)
        {
        try { 
            Role role = GetRoleByRoleId(userRequest.RoleId);
            User user = GetUserById(userRequest.UserId);
            userRepository.RemoveRoleFromUser(user, role);
        }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message, e);
    }
}
    }
}
