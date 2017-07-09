using ESport.Data.Commons;
using System.Collections.Generic;

namespace ESport.Data.Entities
{
    public interface IUserManager
    {
        void AddUser(UserRequest userRequest);
        void EditUser(UserRequest userRequest);
        void RemoveUser(UserRequest userRequest);
        List<User> GetAllUsers();
        List<User> GetAllActiveUsers();
        User GetUserById(string userId);
        void AssignRole(UserRequest userRequest);
        void UpdatePassword(UserRequest request);
        void RemoveRoleFromUser(UserRequest userRequest);
    }
}
