using ESport.Data.Commons;
using ESport.Data.Service;
using ESport.Web.Api.Controllers;
using System;
using System.Linq;
using System.Net.Http;

namespace ESport.Web.Api
{
    public class ControllerHelper
    {
        public static string TOKEN_NAME = "Token";

        public static string GetTokenFromRequest(HttpRequestMessage request)
        {
            string result = null;
            if (request!=null && request.Headers.Contains(ControllerHelper.TOKEN_NAME))
            {
                result = request.Headers.GetValues(ControllerHelper.TOKEN_NAME).First();
            }
            return result;
        }

        public static ControllerResponse CreateSuccessResponse(string message)
        {
            ControllerResponse response = BuildGenericResponse(message);
            response.Success = true;
            return response;
        }

        public static ControllerResponse CreateBadResponse(string message)
        {
            ControllerResponse response = BuildGenericResponse(message);
            response.Success = false;
            return response;
        }

        internal static void ValidateUserRole(HttpRequestMessage request, string[] availableRole)
        {
            UserContextDTO userContext = GetUserContext(request);
            ValidateUserRole(userContext.UserDTO, availableRole);
        }

        private static UserContextDTO GetUserContext(HttpRequestMessage request)
        {
            string token = GetTokenFromRequest(request);
            ValidateToken(token);
            UserContextDTO userContext = LoginContext.GetInstance().GetUserContextByToken(token);
            return userContext;
        }

        private static bool ValidateUserRole(UserDTO userDTO, string[] availableRoles)
        {
            if (userDTO == null)
                throw new OperationException("Ocurrió un error inesperado");
            foreach(string availableRole in availableRoles) { 
                foreach (RoleDTO role in userDTO.Roles)
                {
                    if (role.RoleId.Equals(availableRole))
                    {
                        return true;
                    }
                }
            }
            throw new BadRequestException("No tiene permisos suficientes para esta Operación");
        }

        internal static void ValidateIsTheSameUser(HttpRequestMessage request, string userId)
        {
            UserContextDTO userContextDTO = GetUserContext(request);
            if (!userId.Equals(userContextDTO.UserDTO.UserId) && !ValidateUserRole(userContextDTO.UserDTO, new string[] { ESportUtils.ADMIN_ROLE }))
            {
                throw new BadRequestException("Esta operación no se permite realizar sobre otro usuario");
            }
        }

        public static void ValidateToken(string token)
        {
            if (String.IsNullOrWhiteSpace(token))
            {
                throw new BadRequestException("Debe indicar un token de autenticación");
            }
            ValidateTokenInLoginContext(token);
        }

        private static void ValidateTokenInLoginContext(string token)
        {
            UserContextDTO context=LoginContext.GetInstance().GetUserContextByToken(token);
            if (context==null)
            {
                throw new BadRequestException("Debe estar logueado para esta operación");
            }
        }

        private static ControllerResponse BuildGenericResponse(string message)
        {
            ControllerResponse response = new ControllerResponse();
            response.Message = message;
            return response;
        }

        public static void ValidateAndSetUserInCartRequest(HttpRequestMessage request, CartRequest cartRequest)
        {
            string token = GetTokenFromRequest(request);
            ValidateUserRole(request, new string[] { ESportUtils.CLIENT_ROLE });
            cartRequest.UserId = GetUserIdFromToken(token);
        }

        public static void CalidateAndSetUserInReviewRequest(HttpRequestMessage request, ReviewRequest reviewRequest)
        {
            string token = GetTokenFromRequest(request);
            ValidateUserRole(request,   new string[] { ESportUtils.CLIENT_ROLE });
            reviewRequest.UserId = GetUserIdFromToken(token);
        }

        public static string GetUserIdFromToken(string token)
        {
            return LoginContext.GetInstance().GetUserContextByToken(token).UserDTO.UserId;
        }

    }
}