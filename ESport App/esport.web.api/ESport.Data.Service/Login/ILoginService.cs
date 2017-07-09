using ESport.Data.Commons;

namespace ESport.Data.Service
{
    public interface ILoginService : IService<LoginUserRequest>
    {
        UserContextDTO LoginUser(LoginUserRequest request);
        void Logout(string token);
        
    }
}
