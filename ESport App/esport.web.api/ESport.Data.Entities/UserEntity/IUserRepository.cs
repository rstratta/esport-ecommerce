using System.Collections.Generic;

namespace ESport.Data.Entities
{
    public interface IUserRepository : IRepository<User>
    {

        User GetUserById(string userId);
        List<User> GetAllActiveUsers();
        void RemoveRoleFromUser(User user, Role role);
        void AddRoleInUser(User user, Role role);
    }
}
