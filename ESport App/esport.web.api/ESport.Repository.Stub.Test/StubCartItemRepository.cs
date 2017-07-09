using ESport.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ESport.Repository.Stub.Test
{
    public class StubCartItemRepository : ICartItemRepository
    {
        List<CartItem> cartItems = new List<CartItem>();

        public void AddEntity(CartItem entity)
        {
            if (cartItems.Contains(entity))
            {
                throw new RepositoryException("Item ya existe");
            }
            cartItems.Add(entity);
        }

        public List<CartItem> GetAllEntities()
        {
            return cartItems;
        }

        public CartItem GetCartItemById(Guid cartItemId)
        {
            CartItem result = cartItems.Where(item => item.CartItemId.Equals(cartItemId)).First();
            if (result == null)
            {
                throw new RepositoryException("no se encontró item");
            }
            return result;
        }

        public void RemoveEntity(CartItem entity)
        {
            if (cartItems.Contains(entity))
            {
                cartItems.Remove(entity);
            }
            else
            {
                throw new RepositoryException("Item no existe");
            }

        }

        public void UpdateEntity(CartItem entity)
        {
            if (cartItems.Contains(entity))
            {
                cartItems.Remove(entity);
            }
            cartItems.Add(entity);
        }
    }
}