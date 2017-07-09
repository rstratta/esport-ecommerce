using ESport.Data.Commons;
using System.Collections.Generic;

namespace ESport.Data.Service
{
    public interface IUserService : IService<UserRequest>
    {
        void AddUser(UserRequest request);
        void EditUser(UserRequest request);
        void RemoveUser(UserRequest request);
        List<UserDTO> GetAllUsers();
        List<UserDTO> GetAllActiveUsers();
        UserDTO GetUserById(UserRequest request);
        void UpdatePassword(UserRequest request);
        void AddRoleOnUser(UserRequest userRequest);
        void RemoveRoleFromUser(UserRequest userRequest);
    }
}
