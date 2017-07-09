using ESport.Data.Commons;
using System.Collections.Generic;
using System;

namespace ESport.Data.Entities
{
    public interface ICartManager
    {
        Cart AddProduct(CartRequest request);
        Cart GetCurrentCartByUserId(string userId);
        void ConfirmCart(CartRequest request);
        void CancelCart(CartRequest request);
        List<CartItem> GetItemsPendingOfReview(string userId);
        Cart CancelProduct(CartRequest request);
        List<Cart> GetAllCartsByUser(string userId);
        void MarkCartItemAsReviewed(ReviewRequest request);
        List<ProductItemReportDTO> GetMaxProductSaled(int quantity);
        List<CategoryItemReportDTO> GetCategoryReport(DateTime startDate, DateTime endDate);
    }
}
