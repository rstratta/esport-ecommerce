using ESport.Data.Commons;
using ESport.Data.Entities;
using ESport.Data.Repository;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace ESport.Data.Service
{
    public class LoginContext
    {
        private static LoginContext instance;
        private IUserContextRepository userContextRepository;
        private Dictionary<string, UserContextDTO> context;

        private LoginContext()
        {
            userContextRepository = new UserContextRepository();
        }

        public void Reset()
        {
            ICollection<UserContext> allCOntext = userContextRepository.GetAllEntities();
            foreach (var userContext in allCOntext)
            {
                userContextRepository.RemoveEntity(userContext);
            }
        }
        public static LoginContext GetInstance()
        {
            if (instance == null)
            {
                instance = new LoginContext();
            }
            return instance;
        }

        public string GenerateNewToken(string userId)
        {
            try
            {
                UserContext context = userContextRepository.GetUserContextByUserId(userId);
                return context.Token.ToString();
            }
            catch (RepositoryException e)
            {
            }
            return Guid.NewGuid().ToString();
        }

        public UserContextDTO GetUserContextByToken(string token)
        {
            try
            {
                UserContext context = userContextRepository.GetUserContextByToken(Guid.Parse(token));
                return DeserializeUserContext(context.SerializedContext);
            }
            catch (RepositoryException)
            {
                throw new BadRequestException("Debe estar logueado para esta operación");
            }
        }

        internal void RemoveUserToken(string token)
        {
            try
            {
                UserContext context = userContextRepository.GetUserContextByToken(Guid.Parse(token));
                userContextRepository.RemoveEntity(context);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message, e);
            }

        }

        public void SaveContext(UserContextDTO userContext)
        {
            try
            {
                UserContext context = userContextRepository.GetUserContextByToken(Guid.Parse(userContext.Token));
                context.SerializedContext = SerializeUserContext(userContext);
                userContextRepository.UpdateEntity(context);
            }
            catch (RepositoryException)
            {
                AddNewUserContext(userContext);
            }
        }

        private void AddNewUserContext(UserContextDTO userContext)
        {
            try
            {
                UserContext context = new UserContext();
                context.SerializedContext = SerializeUserContext(userContext);
                context.Token = Guid.Parse(userContext.Token);
                context.UserId = userContext.UserDTO.UserId;
                userContextRepository.AddEntity(context);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message, e);
            }
        }

        private string SerializeUserContext(UserContextDTO userContextDTO)
        {
            var serializedContext=new JavaScriptSerializer().Serialize(userContextDTO);
            return serializedContext;
        }

        public UserContextDTO DeserializeUserContext(string userContext)
        {
            return new JavaScriptSerializer().Deserialize<UserContextDTO>(userContext);
        }
    }
}
