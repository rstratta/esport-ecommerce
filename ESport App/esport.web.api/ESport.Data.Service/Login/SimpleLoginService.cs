using ESport.Data.Commons;
using ESport.Data.Entities;
using ESport.Logger.Manager;

namespace ESport.Data.Service
{
    public class SimpleLoginService : AbstractLoginService
    {
        public SimpleLoginService(IUserManager userManager, IDTOBuilder<UserDTO, User> userDTOBuilder,
            ILoggerManager loggerManager)
        {
            UserManager = userManager;
            UserDTOBuilder = userDTOBuilder;
            LoggerManager = loggerManager;
        }

        protected override UserContextDTO GetUserContext(LoginUserRequest request)
        {
            return new UserContextDTO();
        }
    }
}
