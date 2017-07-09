using ESport.Data.Entities;
using System.Collections.Generic;
using System;

namespace ESport.Repository.Stub.Test
{
    public class StubUserRepository : IUserRepository
    {
        User currentUser;
        public void AddEntity(User entity)
        {
            if (currentUser != null && currentUser.Equals(entity))
            {
                throw new RepositoryException("El usuario ya existe");
            }
            else
            {
                currentUser = entity;
            }
        }

        public void AddRoleInUser(User user, Role role)
        {
            if (currentUser.Roles.Contains(role))
            {
                throw new RepositoryException("el usuario ya tiene el rol");
            }
            currentUser.Roles.Add(role);
        }

        public List<User> GetAllActiveUsers()
        {
            List<User> result = new List<User>();
            if (currentUser != null && !currentUser.Eliminated)
            {
                result.Add(currentUser);
            }
            return result;
        }

        public List<User> GetAllEntities()
        {
            List<User> result = new List<User>();
            if (currentUser != null)
            {
                result.Add(currentUser);
            }
            return result;
        }

        public User GetUserById(string userId)
        {
            if (currentUser != null && currentUser.UserId.Equals(userId))
            {
                return currentUser;
            }
            else
            {
                throw new RepositoryException("No existe Usuario");
            }
        }

        public void RemoveEntity(User entity)
        {
            currentUser.Eliminated = true;
        }

        public void RemoveRoleFromUser(User user, Role role)
        {
            currentUser.Roles.Remove(role);
        }

        public void UpdateEntity(User entity)
        {
            currentUser = entity;
        }
    }
}
