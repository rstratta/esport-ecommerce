using ESport.Data.Commons;
using System.Collections.Generic;

namespace ESport.Data.Service
{
    public interface IReviewService : IService<ReviewRequest>
    {
        void AddReview(ReviewRequest request);
        List<ReviewDTO> GetReviewsByProductId(string productId);
    }
}
