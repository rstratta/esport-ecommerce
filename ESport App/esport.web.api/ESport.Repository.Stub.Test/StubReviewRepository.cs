using ESport.Data.Entities;
using System;
using System.Collections.Generic;

namespace ESport.Repository.Stub.Test
{
    public class StubReviewRepository: IReviewRepository
    {
        Review currentReview;
        public void AddEntity(Review entity)
        {
            currentReview = entity;
        }

        public List<Review> GetAllByProduct(Product productToReview)
        {
            List<Review> result = new List<Review>();
            if (currentReview != null && currentReview.Product.Equals(productToReview))
            {
                result.Add(currentReview);
            }
            return result;
        }

        public List<Review> GetAllByUser(User userForReview)
        {
            List<Review> result = new List<Review>();
            if (currentReview != null && currentReview.User.Equals(userForReview))
            {
                result.Add(currentReview);
            }
            return result;
        }

        public List<Review> GetAllEntities()
        {
            List<Review> result = new List<Review>();
            if (currentReview != null)
            {
                result.Add(currentReview);
            }
            return result;
        }

        public void RemoveEntity(Review entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(Review entity)
        {
            throw new NotImplementedException();
        }
    }
}