using System.Collections.Generic;

namespace ESport.Data.Entities
{
    public interface IReviewRepository : IRepository<Review>
    {
        List<Review> GetAllByProduct(Product productToReview);
        List<Review> GetAllByUser(User userForReview);
    }
}
