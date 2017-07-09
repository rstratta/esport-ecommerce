using ESport.Data.Commons;
using System.Collections.Generic;
using System;

namespace ESport.Data.Entities
{
    public class CartManager : ICartManager
    {
        private IUserRepository userRepository;
        private IProductRepository productRepository;
        private ICartRepository cartRepository;
        private ICartItemRepository cartItemRepository;
        private IPointSystemConfigurationRepository configurationRepository;
        

        public CartManager(ICartRepository cartRepository, 
            ICartItemRepository cartItemRepository,
            IProductRepository productRepository, 
            IUserRepository userRepository,
            IPointSystemConfigurationRepository configurationRepository)
        {
            this.userRepository = userRepository;
            this.productRepository = productRepository;
            this.cartRepository = cartRepository;
            this.cartItemRepository = cartItemRepository;
            this.configurationRepository = configurationRepository;
        }
        public Cart AddProduct(CartRequest request)
        {
            Cart currentCart = GetCartByUser(request.UserId);
            AddCartItem(currentCart, request.ProductId, request.Quantity);
            return currentCart;
        }

        private void AddCartItem(Cart currentCart, string productId, int quantity)
        {
            CartItem itemToAdd = CreateCartItem(productId, quantity);
            AddItemInCart(currentCart, itemToAdd);
            UpdateAndSaveCart(currentCart);
        }

        public Cart CancelProduct(CartRequest request)
        {
            Cart currentCart = GetCartByUser(request.UserId);
            CancelItem(currentCart, request.ProductId, request.Quantity);
            return currentCart;
        }

        private void CancelItem(Cart currentCart, string productId, int quantity)
        {
            CartItem itemToCancel = CreateCartItem(productId, quantity);
            CancelItemInCart(currentCart, itemToCancel);
            UpdateAndSaveCart(currentCart);
        }

        private void UpdateAndSaveCart(Cart currentCart)
        {
            UpdateCartTotal(currentCart);
            SaveCartAndItems(currentCart);
        }

        private void SaveCartAndItems(Cart cart)
        {
            SaveCart(cart);
            SaveItems(cart.Items);
        }

        private void SaveItems(ICollection<CartItem> items)
        {
            foreach (CartItem item in items)
            {
                if (item.Quantity == ESportUtils.ZERO)
                {
                    RemoveCartItem(item);
                    break;
                }
                else
                {
                    AddOrUpdateCartItem(item);
                }
            }
        }

        private void RemoveCartItem(CartItem item)
        {
            cartItemRepository.RemoveEntity(item);
        }

        private void AddOrUpdateCartItem(CartItem item)
        {
            try
            {
                cartItemRepository.UpdateEntity(item);
            }
            catch (RepositoryException)
            {
                try
                {
                    cartItemRepository.AddEntity(item);
                }
                catch (RepositoryException e)
                {
                    throw new OperationException(e.Message,e);
                }
            }
        }

        private CartItem CreateCartItem(string productId, int quantity)
        {
            Product productToAdd = productRepository.GetProductById(productId);
            if (!productToAdd.Eliminated)
            {
                return new CartItem(productToAdd, quantity);
            }
            else
            {
                throw new OperationException("El producto que intenta vender, se encuentra eliminado");
            }

        }

        private void CancelItemInCart(Cart cart, CartItem itemToCancel)
        {
            bool itemRemoved = false;
            foreach (CartItem item in cart.Items)
            {
                if (item.Equals(itemToCancel))
                {
                    item.Quantity -= itemToCancel.Quantity;
                    item.Amount -= itemToCancel.Amount;
                    if (item.Quantity < ESportUtils.ZERO)
                    {
                        throw new OperationException("Verifique la cantidad a eliminar del producto.");
                    }

                    itemRemoved = true;
                    break;
                }
            }
            if (!itemRemoved)
            {
                throw new OperationException("El prudcto que desea cancelar no está en el carrito");
            }
        }

      
        private void UpdateCartTotal(Cart cart)
        {
            double cartTotal = 0;
            foreach (CartItem item in cart.Items)
            {
                cartTotal += item.Amount;
            }
            cart.Total = cartTotal;
        }

        private void SaveCart(Cart cart)
        {
            try
            {
                cartRepository.UpdateEntity(cart);
            }
            catch (RepositoryException)
            {
                try
                {
                    cartRepository.AddEntity(cart);
                }
                catch (RepositoryException e)
                {
                    throw new OperationException(e.Message,e);
                }
            }
        }

        private void AddItemInCart(Cart cart, CartItem itemToAdd)
        {
            bool itemAdded = false;
            foreach (CartItem item in cart.Items)
            {
                if (item.Equals(itemToAdd))
                {
                    item.Quantity += itemToAdd.Quantity;
                    item.Amount += itemToAdd.Amount;
                    itemAdded = true;
                    break;
                }
            }
            if (!itemAdded)
            {
                cart.Items.Add(itemToAdd);
            }
        }

        private Cart GetCartByUser(string userId)
        {
            User currentUser;
            try { 
                currentUser = GetCurrentUser(userId);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
            Cart currentCart;
            try
            {
                currentCart = cartRepository.GetCurrentCartByUser(currentUser);
            }
            catch (RepositoryException)
            {
                currentCart = new Cart();
            }
            currentCart.User = currentUser;
            return currentCart;
        }

        public Cart GetCurrentCartByUserId(string userId)
        {
            try
            {
                User currentUser = GetCurrentUser(userId);
                return cartRepository.GetCurrentCartByUser(currentUser);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }

        public void ConfirmCart(CartRequest request)
        {
            try
            {
                Cart currentCart = GetCurrentCartByUserId(request.UserId);
                CheckCartTotal(currentCart);
                CheckProductAndStock(currentCart.Items);
                UpdateProductStock(currentCart.Items);
                UpdateUserPoints(currentCart, request.UserId);
                UpdateDeliveryInfo(currentCart, request);
                UpdateCartState(currentCart, Cart.FINISHED_CART);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }

        private void UpdateProductStock(ICollection<CartItem> items)
        {
            foreach (var item in items)
            {
                Product productToUpdate= productRepository.GetProductById(item.Product.ProductId);
                productToUpdate.AvailableStock -= item.Quantity;
                productRepository.UpdateEntity(productToUpdate);
            }
        }

        private void CheckProductAndStock(ICollection<CartItem> items)
        {
            foreach (var item in items)
            {
                int nextQuantity = item.Product.AvailableStock- item.Quantity;
                if (nextQuantity<0)
                {
                    throw new OperationException("No es posible confirmar su carrito. No hay suficiente stock del producto " + item.Product.Description);
                }
                if (item.Product.Eliminated)
                {
                    throw new OperationException("No es posible confirmar su carrito. El producto " + item.Product.Description + " ha sido eliminado recientemente.");
                }
            }
        }

        private void UpdateUserPoints(Cart currentCart, string userId)
        {
            PointSystemConfiguration pointSystemConfiguration = configurationRepository.GetByPropertyName(ESportUtils.LOYALTY_PROPERTY_NAME);
            int totalPoints = CalculateLoyaltyPoints(Convert.ToDouble(pointSystemConfiguration.PropertyValue), currentCart.Items);
            User currentUser = GetCurrentUser(userId);
            currentUser.Points+= totalPoints;
            userRepository.UpdateEntity(currentUser);
        }

        private int CalculateLoyaltyPoints(double pointSystemConfigurationValue, ICollection<CartItem> items)
        {
            int points = 0;
            foreach (var item in items)
            {
                if (!IsBlackProduct(item.Product))
                {
                    points+= Convert.ToInt32(item.Amount/pointSystemConfigurationValue);
                }
            }
            return points;
        }

        private bool IsBlackProduct(Product product)
        {
            return product.BlackProduct;
        }

        private void UpdateDeliveryInfo(Cart currentCart, CartRequest request)
        {
            User currentUser = GetCurrentUser(request.UserId);
            UpdateDeliveryAddress(currentCart, request, currentUser);
            UpdateDeliveryPhone(currentCart, request, currentUser);
        }

        private void UpdateDeliveryPhone(Cart currentCart, CartRequest request, User currentUser)
        {
            if (String.IsNullOrWhiteSpace(request.DeliveryPhone))
            {

                currentCart.DeliveryPhone = currentUser.Phone;
            }
            else
            {
                currentCart.DeliveryPhone = request.DeliveryPhone;
            }
        }

        private void UpdateDeliveryAddress(Cart currentCart, CartRequest request, User currentUser)
        {
            if (String.IsNullOrWhiteSpace(request.DeliveryAddress))
            {
                
                currentCart.DeliveryAddress = currentUser.Address;
            }
            else
            {
                currentCart.DeliveryAddress = request.DeliveryAddress;
            }
        }

        private void CheckCartTotal(Cart currentCart)
        {
            if (currentCart.Total <= 0)
            {
                throw new OperationException("No es posible confirmar el carro con total 0");
            }
        }

        private User GetCurrentUser(string userId)
        {
            try
            {
                return userRepository.GetUserById(userId);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }

        public void CancelCart(CartRequest request)
        {
            try
            {
                Cart currentCart = GetCurrentCartByUserId(request.UserId);
                UpdateCartState(currentCart, Cart.CANECELED_CART);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }

        private void UpdateCartState(Cart currentCart, string stateCart)
        {
            currentCart.State = stateCart;
            SaveCart(currentCart);
        }

        public List<CartItem> GetItemsPendingOfReview(string userId)
        {
            try
            {
                return cartRepository.AllCartItemsPendingOfReview(GetCurrentUser(userId));
            }
            catch (RepositoryException)
            {
                return new List<CartItem>();
            }
        }

        public List<Cart> GetAllCartsByUser(string userId)
        {
            try
            {
                return cartRepository.GetAllCartsByUser(GetCurrentUser(userId));
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }

        public void MarkCartItemAsReviewed(ReviewRequest request)
        {
            try {
                CartItem item = cartItemRepository.GetCartItemById(Guid.Parse(request.CartItemId));
                item.PendingReview = false;
                cartItemRepository.UpdateEntity(item);
            }
            catch(RepositoryException e)
            {
                throw new OperationException(e.Message,e);
            }
        }

        public List<ProductItemReportDTO> GetMaxProductSaled(int quantity)
        {
            ICollection<ProductReportRow> result=cartRepository.GetMaxProductSaled(quantity);
            List<ProductItemReportDTO> dtos = new List<ProductItemReportDTO>();
            foreach (var item in result)
            {
                dtos.Add(new ProductItemReportDTO() { Description = item.Description, Quantity = item.Quantity, ProductId = item.ProductId });
            }
            return dtos;
        }

        public List<CategoryItemReportDTO> GetCategoryReport(DateTime startDate, DateTime endDate)
        {
            ICollection<CategoryReportRow> result = cartRepository.GetCategoryReport(startDate, endDate);
            List<CategoryItemReportDTO> dtos = new List<CategoryItemReportDTO>();
            foreach (var item in result)
            {
                dtos.Add(new CategoryItemReportDTO() { Category = item.CategoryReport, Amount = item.AmountReport, Avg = item.AVGReport });
            }
            return dtos;
        }
    }
}
