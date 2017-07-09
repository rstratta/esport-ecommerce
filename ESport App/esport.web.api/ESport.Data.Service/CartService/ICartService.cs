using ESport.Data.Commons;
using System.Collections.Generic;

namespace ESport.Data.Service
{
    public interface ICartService : IService<CartRequest>
    {
        CartDTO AddProduct(CartRequest request);
        CartDTO RemoveProduct(CartRequest request);
        void ConfirmCart(CartRequest request);
        void CancelCart(CartRequest request);
        List<CartDTO> GetAllCartsByUser(CartRequest request);
        AbstractReportDTO GetMaxProductSaled(int quantity);
        AbstractReportDTO GetCategoryReport(string startD, string finishD);

        List<PendingReviewDTO> GetPendingReviewsForUser(string userId);
    }
}
