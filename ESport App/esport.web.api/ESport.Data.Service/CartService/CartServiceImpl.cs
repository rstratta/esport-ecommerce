using ESport.Data.Commons;
using ESport.Data.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ESport.Data.Service
{
    public class CartServiceImpl : ICartService
    {
        private ICartManager cartManager;
        private IDTOBuilder<CartDTO, Cart> cartBuilderDTO;
        private IDTOBuilder<PendingReviewDTO, CartItem> pendgingReviewDTOBuilder;


        public CartServiceImpl(ICartManager cartManager, IDTOBuilder<CartDTO, Cart> cartBuilder, IDTOBuilder<PendingReviewDTO, CartItem> pendgingReviewDTOBuilder)
        {
            this.cartManager = cartManager;
            cartBuilderDTO = cartBuilder;
            this.pendgingReviewDTOBuilder = pendgingReviewDTOBuilder;
        }

        public CartDTO AddProduct(CartRequest request)
        {
            ValidateRequest(request);
            Cart currentCart=cartManager.AddProduct(request);
            return cartBuilderDTO.buildDTO(currentCart);
        }

        public CartDTO RemoveProduct(CartRequest request)
        {
            ValidateRequest(request);
            Cart currentCart = cartManager.CancelProduct(request);
            return cartBuilderDTO.buildDTO(currentCart);
        }

        public void ValidateRequest(CartRequest request)
        {
            ValidateMandatoryFields(request);
        }

        private void ValidateMandatoryFields(CartRequest request)
        {
            ValidateUserId(request.UserId);
            ValidateProductId(request.ProductId);
            ValidateQuantity(request.Quantity);
        }

        private void ValidateProductId(string productId)
        {
            if (String.IsNullOrWhiteSpace(productId))
            {
                throw new BadRequestException("El código de producto es obligatorio para la operacion");
            }
        }

        private void ValidateUserId(string userId)
        {
            if (String.IsNullOrWhiteSpace(userId))
            {
                throw new BadRequestException("El Id de usuario es obligatorio para la operación.");
            }
        }


        private void ValidateQuantity(int quantity)
        {
            if(quantity <= 0)
            {
                throw new BadRequestException("La cantidad debe ser mayor a 0");
            }
        }

        public void ConfirmCart(CartRequest request)
        {
            ValidateUserId(request.UserId);
            cartManager.ConfirmCart(request);
        }

        public void CancelCart(CartRequest request)
        {
            ValidateUserId(request.UserId);
            cartManager.CancelCart(request);
        }

        public List<CartDTO> GetAllCartsByUser(CartRequest request)
        {
            ValidateUserId(request.UserId);
            List<Cart> userCarts=cartManager.GetAllCartsByUser(request.UserId);
            return BuildCartListDTO(userCarts);
        }

        private List<CartDTO> BuildCartListDTO(List<Cart> userCarts)
        {
            List<CartDTO> result = new List<CartDTO>();
            foreach (Cart cart in userCarts)
            {
                result.Add(cartBuilderDTO.buildDTO(cart));
            }
            return result;
        }

        public AbstractReportDTO GetMaxProductSaled(int quantity)
        {
            List<ProductItemReportDTO> result = cartManager.GetMaxProductSaled(quantity);
            AbstractReportDTO report = new ProductReportDTO("Reporte de productos más vendidos", result);
            return report;
        }

        public AbstractReportDTO GetCategoryReport(string startD, string finishD)
        {
            DateTime startDate= ParseDate(startD,"00","00");
            DateTime endDate=ParseDate(finishD,"23","59");
            ValidateDate(startDate, endDate);
            List<CategoryItemReportDTO> result = cartManager.GetCategoryReport(startDate, endDate);
            AbstractReportDTO report = new CategoryReportDTO("Reporte de ventas por categoría", result);
            return report;
        }

        private void ValidateDate(DateTime startDate, DateTime endDate)
        {
            if (endDate.CompareTo(startDate) < 0)
            {
                throw new BadRequestException("La fecha de inicio no puede ser mayor a la final");
            }
        }

        private DateTime ParseDate(string dateStr, string hour, string minute)
        {
            if (String.IsNullOrWhiteSpace(dateStr))
            {
               return CreateDate(hour,minute,0);
            }
            else
            {
                dateStr += " "+hour+":"+minute;
                try { 
                    return DateTime.ParseExact(dateStr, "yyyyMMdd HH:mm", CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    throw new BadRequestException("Verifique la fecha ingresada");
                }
            }
        }

        private DateTime CreateDate(string hour, string minute, int seconds)
        {
            DateTime helper = DateTime.Now;
            return new DateTime(helper.Year, helper.Month, helper.Day, Int32.Parse(hour), Int32.Parse(minute), seconds);
        }

        public List<PendingReviewDTO> GetPendingReviewsForUser(string userId)
        {
            List<CartItem> pendingReviews = cartManager.GetItemsPendingOfReview(userId);
            List<PendingReviewDTO> result = new List<PendingReviewDTO>();
            foreach (CartItem item in pendingReviews)
            {
                result.Add(pendgingReviewDTOBuilder.buildDTO(item));
            }
            return result;
        }
    }
}
