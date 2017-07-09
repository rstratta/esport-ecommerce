using ESport.Data.Entities;
using System;
using System.Collections.Generic;

namespace ESport.Repository.Stub.Test
{
    public class StubCartRepository : ICartRepository
    {
        public static Guid CART_ITEM_ID = Guid.NewGuid();
        Cart currentCart;
        public void AddEntity(Cart entity)
        {
            if (currentCart == null && !entity.State.Equals(Cart.PENDING_CART))
            {
                currentCart = entity;
            }
            else
            {
                throw new RepositoryException("Ya existe un carro en curso");
            }

        }

        public List<CartItem> AllCartItemsPendingOfReview(User user)
        {
            List<Cart> allCarts = GetAllCartsByUser(user);
            List<CartItem> items = new List<CartItem>();
            foreach (Cart cart in allCarts)
            {
                GetPendingOfReview(items, cart);
            }
            return items;
        }

        private void GetPendingOfReview(List<CartItem> cartItemResult, Cart cart)
        {
            foreach (CartItem item in cart.Items)
            {
                if (item.PendingReview)
                {
                    cartItemResult.Add(item);
                }
            }
        }



        public List<Cart> GetAllEntities()
        {
            List<Cart> result = new List<Cart>();
            if (currentCart != null)
            {
                result.Add(currentCart);
            }
            return result;
        }

        public Cart GetCurrentCartByUser(User currentUser)
        {
            if (currentCart != null && currentCart.User.Equals(currentUser) && currentCart.State.Equals(Cart.INIT_CART))
            {
                return currentCart;
            }
            throw new RepositoryException("El usuario no tiene un carro en curso");
        }

        public void RemoveEntity(Cart entity)
        {
            throw new RepositoryException("Esta entidad no puede ser eliminada");
        }

        public void UpdateEntity(Cart entity)
        {
            if (currentCart != null && currentCart.Equals(entity))
            {
                currentCart = entity;
            }
            else
            {
                throw new RepositoryException("No existe el carro a actualizar");
            }
        }

        public List<Cart> GetAllCartsByUser(User user)
        {
            List<Cart> result = new List<Cart>();
            if (currentCart != null && currentCart.User.Equals(user) && currentCart.State.Equals(Cart.FINISHED_CART))
            {
                result.Add(currentCart);
            }
            return result;
        }

        public ICollection<ProductReportRow> GetMaxProductSaled(int quantity)
        {
            throw new NotImplementedException();
        }

        public ICollection<CategoryReportRow> GetCategoryReport(DateTime startDate, DateTime enddate)
        {
            throw new NotImplementedException();
        }
    }
}
