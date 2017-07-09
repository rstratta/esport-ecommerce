using ESport.Data.Commons;
using System.Collections.Generic;

namespace ESport.Data.Entities
{
    public class ReviewManager : IReviewManager
    {
        private IReviewRepository reviewRepository;
        private IProductRepository productRepository;
        private IUserRepository userRepository;

        public ReviewManager(IReviewRepository reviewRepository, IUserRepository userRepository, IProductRepository productRepository)
        {
            this.reviewRepository = reviewRepository;
            this.productRepository = productRepository;
            this.userRepository = userRepository;
        }
        public void AddReview(ReviewRequest request)
        {
            try
            {
                Product productToReview = productRepository.GetProductById(request.ProductId);
                User userReview = userRepository.GetUserById(request.UserId);
                Review review = new Review(userReview, productToReview, request.Description, request.Points);
                reviewRepository.AddEntity(review);
                UpdateProductReviewAverage(productToReview);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }

        private void UpdateProductReviewAverage(Product productToReview)
        {
            try
            {
                List<Review> reviewsByProducts = reviewRepository.GetAllByProduct(productToReview);
                double totalPoints = 0;
                foreach (Review review in reviewsByProducts)
                {
                    totalPoints += review.Points;
                }
                productToReview.ReviewAverage = totalPoints / reviewsByProducts.Count;
                productRepository.UpdateEntity(productToReview);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }

        public List<Review> GetReviewsByProduct(string productId)
        {
            try
            {
                Product productForReview = productRepository.GetProductById(productId);
                return reviewRepository.GetAllByProduct(productForReview);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }

        public List<Review> GetReviewsByUser(User userForReview)
        {
            try
            {
                return reviewRepository.GetAllByUser(userForReview);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }
    }
}
