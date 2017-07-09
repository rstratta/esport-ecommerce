using ESport.Data.Entities;
using ESport.Logger.Manager;
using System;
using ESport.Data.Commons;

namespace ESport.Data.Service
{
    public abstract class AbstractLoginService : ILoginService
    {
        public  ILoggerManager LoggerManager { get; set; }
        public IUserManager UserManager { get; set; }
        public IDTOBuilder<UserDTO, User> UserDTOBuilder { get; set; }

        public UserContextDTO LoginUser(LoginUserRequest request)
        {
            ValidateRequest(request);
            User user = GetAndValidateUser(request);
            UserContextDTO context = GetUserContext(request);
            FillContext(context, user);
            LoginContext.GetInstance().SaveContext(context);
            LoggerManager.AddLog(ESportLoggerUtils.LOGIN_ACTION, user.UserId, user.UserName);
            return context;
        }

        private void FillContext(UserContextDTO context, User user)
        {
            UserDTO userDTO= GetUserDTO(user);
            context.UserDTO = userDTO;
            context.Token = LoginContext.GetInstance().GenerateNewToken(userDTO.UserId);
        }

        protected abstract UserContextDTO GetUserContext(LoginUserRequest request);

        public void Logout(string token)
        {
            LoginContext.GetInstance().RemoveUserToken(token);
        }

        private User GetAndValidateUser(LoginUserRequest request)
        {
            User user = UserManager.GetUserById(request.UserId);
            ValidateUser(user, request.UserPassword);
            return user;
        }

        private void ValidateUser(User user, string userInputPassword)
        {
            ValidateUserIsEliminated(user);
            ValidateLoginUserPassword(user.Password, userInputPassword);
        }

        public void ValidateRequest(LoginUserRequest request)
        {
            ValidateUserId(request.UserId);
            ValidatePassword(request.UserPassword);
        }

        private void ValidateUserId(string userId)
        {
            if (String.IsNullOrWhiteSpace(userId))
            {
                throw new BadRequestException("El id de usuario es necesario para el login");
            }
        }

        private void ValidatePassword(string userPassword)
        {
            if (String.IsNullOrWhiteSpace(userPassword))
            {
                throw new BadRequestException("El password de usuario es necesario para el login");
            }
        }

        private void ValidateUserIsEliminated(User user)
        {
            if (user.Eliminated)
            {
                throw new OperationException("El usuario se encuentra elimiando");
            }
        }

        private void ValidateLoginUserPassword(string password, object userInputPassword)
        {
            if (!password.Equals(userInputPassword))
            {
                throw new OperationException("El password ingresado no es correcto");
            }
        }

        protected UserDTO GetUserDTO(User user)
        {
            return UserDTOBuilder.buildDTO(user);
        }

    }
}
