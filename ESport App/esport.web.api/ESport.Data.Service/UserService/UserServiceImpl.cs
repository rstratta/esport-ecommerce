using ESport.Data.Commons;
using ESport.Data.Entities;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace ESport.Data.Service
{
    public class UserServiceImpl : IUserService
    {
        private IUserManager userManager;
        private IDTOBuilder<UserDTO, User> dtoBuilder;

        public UserServiceImpl(IUserManager userManager, IDTOBuilder<UserDTO, User> dtoBuilder)
        {
            this.userManager = userManager;
            this.dtoBuilder = dtoBuilder;
        }

        public void AddUser(UserRequest request)
        {
            ValidateRequest(request);
            ValidatePassword(request.Password);
            userManager.AddUser(request);
        }

        public void ValidateRequest(UserRequest request)
        {
            ValidateManadatoryFields(request);
            ValidateRoleId(request);
        }

        private void ValidateManadatoryFields(UserRequest request)
        {
            ValidateUserId(request);
            ValidateUserName(request);
            ValidateLastName(request);
            ValidateAddress(request);
            ValidateMail(request);
        }

        private void ValidateMail(UserRequest request)
        {
            try
            {
                new MailAddress(request.EMail);
            }
            catch (Exception)
            {
                throw new BadRequestException("Verifique la dirección de correo electrónico");
            }
        }

        private void ValidateAddress(UserRequest request)
        {
            if (String.IsNullOrWhiteSpace(request.Address))
            {
                throw new BadRequestException("La dirección del usuario es obligatoria para esta operación");
            }
        }

        private void ValidateLastName(UserRequest request)
        {
            if (String.IsNullOrWhiteSpace(request.UserLastName))
            {
                throw new BadRequestException("El apellido del usuario es obligatorio para esta operación");
            }
        }

        private void ValidateUserName(UserRequest request)
        {
            if (String.IsNullOrWhiteSpace(request.UserName))
            {
                throw new BadRequestException("El nombre del usuario es obligatorio para esta operación");
            }
        }

        private void ValidateRoleId(UserRequest request)
        {
            if (String.IsNullOrWhiteSpace(request.RoleId))
            {
                throw new BadRequestException("El rol del usuario es obligatorio para esta operación");
            }
        }


        private void ValidateUserId(UserRequest request)
        {
            if (String.IsNullOrWhiteSpace(request.UserId))
            {
                throw new BadRequestException("El id de usuario es obligatorio para esta operación");
            }
        }

        public void EditUser(UserRequest request)
        {
            ValidateManadatoryFields(request);
            userManager.EditUser(request);

        }

        public void RemoveUser(UserRequest request)
        {
            ValidateUserId(request);
            userManager.RemoveUser(request);
        }

        public List<UserDTO> GetAllUsers()
        {
            List<User> result= userManager.GetAllUsers();
            return BuildUserListDTO(result);
        }

        private List<UserDTO> BuildUserListDTO(List<User> userList)
        {
            List<UserDTO> result = new List<UserDTO>();
            foreach(User user in userList)
            {
                result.Add(BuildDTO(user));
            }
            return result;
        }

        private UserDTO BuildDTO(User user)
        {
            return dtoBuilder.buildDTO(user);
        }

        public List<UserDTO> GetAllActiveUsers()
        {
            List<User> activeUsers = userManager.GetAllActiveUsers();
            return BuildUserListDTO(activeUsers);
        }

        public UserDTO GetUserById(UserRequest request)
        {
            ValidateUserId(request);
            User currentUser = userManager.GetUserById(request.UserId);
            return BuildDTO(currentUser);
        }

        public void UpdatePassword(UserRequest request)
        {
            ValidateUpdatePasswordRequest(request);
            userManager.UpdatePassword(request);
        }

        private void ValidateUpdatePasswordRequest(UserRequest request)
        {
            ValidateUserId(request);
            ValidatePassword(request.Password);
            ValidatePassword(request.NewPassword);
        }

        private void ValidatePassword(string password)
        {
            if (String.IsNullOrWhiteSpace(password))
            {
                throw new BadRequestException("Verifique password en esta operación");
            }
        }

        public void AddRoleOnUser(UserRequest userRequest)
        {
            ValidateUserId(userRequest);
            ValidateRoleId(userRequest);
            userManager.AssignRole(userRequest);

        }

        public void RemoveRoleFromUser(UserRequest userRequest)
        {
            ValidateUserId(userRequest);
            ValidateRoleId(userRequest);
            userManager.RemoveRoleFromUser(userRequest);
        }
    }
}
