using ESport.Data.Commons;
using ESport.Data.Entities;

namespace ESport.Data.Service
{
    public class PendingReviewDTOBuilder : IDTOBuilder<PendingReviewDTO, CartItem>
    {
        public PendingReviewDTO buildDTO(CartItem entity)
        {
            PendingReviewDTO pendingReviewDTO = new PendingReviewDTO();
            pendingReviewDTO.CartItemId = entity.CartItemId.ToString();
            pendingReviewDTO.ItemDescription = entity.ItemDescription;
            pendingReviewDTO.ProductId = entity.Product.ProductId;
            return pendingReviewDTO;
        }
    }
}
