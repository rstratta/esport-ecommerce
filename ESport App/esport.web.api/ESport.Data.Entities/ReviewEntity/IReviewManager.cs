using ESport.Data.Commons;
using ESport.Data.Entities;
using System.Collections.Generic;

namespace ESport.Data.Entities
{
    public interface IReviewManager
    {
        void AddReview(ReviewRequest request);
        List<Review> GetReviewsByProduct(string productId);
        List<Review> GetReviewsByUser(User userForReview);
    }
}
