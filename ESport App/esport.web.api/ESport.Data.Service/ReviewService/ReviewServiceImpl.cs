using ESport.Data.Commons;
using ESport.Data.Entities;
using System;
using System.Collections.Generic;

namespace ESport.Data.Service
{
    public class ReviewServiceImpl : IReviewService
    {
        private ICartManager cartManager;
        private IReviewManager reviewManager;
        private IDTOBuilder<ReviewDTO, Review> reviewDTOBuilder;

        public ReviewServiceImpl(IReviewManager reviewManager, ICartManager cartManager, IDTOBuilder<ReviewDTO, Review> reviewDTOBuilder)
        {
            this.reviewManager = reviewManager;
            this.cartManager = cartManager;
            this.reviewDTOBuilder = reviewDTOBuilder;
        }

        public void AddReview(ReviewRequest request)
        {
            ValidateRequest(request);
            reviewManager.AddReview(request);
            cartManager.MarkCartItemAsReviewed(request);
        }

        public void ValidateRequest(ReviewRequest request)
        {
            ValidateUserId(request.UserId);
            ValidatePoints(request.Points);
            ValidateProductId(request.ProductId);
            ValidateDescription(request.Description);
            ValidateCartItemId(request.CartItemId);
        }

        private void ValidateUserId(string userId)
        {
            if (String.IsNullOrWhiteSpace(userId))
            {
                throw new BadRequestException("El id de usuario es obligatorio para la operación");
            }
        }

        private void ValidateProductId(string productId)
        {
            if (String.IsNullOrWhiteSpace(productId))
            {
                throw new BadRequestException("El id de producto es obligatorio para la operación");
            }
        }

        private void ValidatePoints(int points)
        {
            if(points<=0 || points > 5)
            {
                throw new BadRequestException("El puntaje permitido es entre 1 y 5");
            }
        }

        private void ValidateDescription(string description)
        {
            if (String.IsNullOrWhiteSpace(description))
            {
                throw new BadRequestException("La descripción es obligatorio para la operación");
            }
        }

        private void ValidateCartItemId(string cartItemId)
        {
            if (String.IsNullOrWhiteSpace(cartItemId))
            {
                throw new BadRequestException("Verifique el item de carro seleccionado");
            }
        }

        public List<ReviewDTO> GetReviewsByProductId(string productId)
        {
            ValidateProductId(productId);
            List<Review> reviews = reviewManager.GetReviewsByProduct(productId);
            return BuildReviewDTOList(reviews);
        }

        private List<ReviewDTO> BuildReviewDTOList(List<Review> reviews)
        {
            List<ReviewDTO> reviewsDTO = new List<ReviewDTO>();
            foreach (Review review in reviews)
            {
                reviewsDTO.Add(reviewDTOBuilder.buildDTO(review));
            }
            return reviewsDTO;
        }
    }
}
