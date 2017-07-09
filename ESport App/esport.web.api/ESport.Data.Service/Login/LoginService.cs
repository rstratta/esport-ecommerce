using System.Collections.Generic;
using ESport.Data.Commons;
using ESport.Data.Entities;
using ESport.Logger.Manager;

namespace ESport.Data.Service
{
    public class LoginService : AbstractLoginService
    {
        
        private ICartManager cartManager;
        private IDTOBuilder<PendingReviewDTO, CartItem> pendgingReviewDTOBuilder;
        private IDTOBuilder<CartDTO, Cart> cartDTOBuilder;
        
        

        public LoginService(IUserManager userManager, ICartManager cartManager,
            IDTOBuilder<PendingReviewDTO, CartItem> pendgingReviewDTOBuilder, 
            IDTOBuilder<CartDTO, Cart> cartDTOBuilder, 
            IDTOBuilder<UserDTO, User> userDTOBuilder,
            ILoggerManager loggerManager)
        {
            this.UserManager = userManager;
            this.cartManager = cartManager;
            this.pendgingReviewDTOBuilder = pendgingReviewDTOBuilder;
            this.cartDTOBuilder = cartDTOBuilder;
            this.UserDTOBuilder = userDTOBuilder;
            this.LoggerManager = loggerManager;
        }


        protected override UserContextDTO GetUserContext(LoginUserRequest request)
        {
            List<PendingReviewDTO> pendingReviews = GetPendingReviewsForUser(request);
            CartDTO pendingCart = GetPendingCartForUser(request.UserId);
            return  BuildResponseDTO(pendingReviews, pendingCart);
        }
        

        private CartDTO GetPendingCartForUser(string userId)
        {
            try
            {
                Cart pendingCart = cartManager.GetCurrentCartByUserId(userId);
                return cartDTOBuilder.buildDTO(pendingCart);
            }
            catch (OperationException)
            {

            }
            return null;
        }

        private List<PendingReviewDTO> GetPendingReviewsForUser(LoginUserRequest request)
        {
            List<CartItem> pendingReviews = cartManager.GetItemsPendingOfReview(request.UserId);
            List<PendingReviewDTO> result = new List<PendingReviewDTO>();
            foreach (CartItem item in pendingReviews)
            {
                result.Add(pendgingReviewDTOBuilder.buildDTO(item));
            }
            return result;
        }

        private UserContextDTO BuildResponseDTO(List<PendingReviewDTO> pendingReviews, CartDTO pendingCart)
        {
            UserContextDTO response = new UserContextDTO();
            response.PendingsReviewDTO = pendingReviews;
            response.PendingCart = pendingCart;
            return response;
        }

        
    }
}
