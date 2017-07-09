using System;
using System.Collections.Generic;

namespace ESport.Data.Entities
{
    public interface ICartRepository : IRepository<Cart>
    {
        Cart GetCurrentCartByUser(User currentUser);
        List<CartItem> AllCartItemsPendingOfReview(User user);
        List<Cart> GetAllCartsByUser(User user);
        ICollection<ProductReportRow> GetMaxProductSaled(int quantity);
        ICollection<CategoryReportRow> GetCategoryReport(DateTime startDate, DateTime endDate);
    }
}
