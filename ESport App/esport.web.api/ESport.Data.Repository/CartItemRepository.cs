using ESport.Data.DataAccess;
using ESport.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ESport.Data.Repository
{
    public class CartItemRepository : ICartItemRepository
    {
        public void AddEntity(CartItem entity)
        {
            using (var db = new ESportDbContext())
                try
                {
                    if (entity.Product != null)
                        db.Entry(entity.Product).State = EntityState.Unchanged;
                    if (entity.Cart != null)
                        db.Entry(entity.Cart).State = EntityState.Unchanged;
                    
                    db.CartItem.Add(entity);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al agregar item al carrito", e);
                }
        }

        public List<CartItem> GetAllEntities()
        {
            using (var db = new ESportDbContext())
                try
                {
                    var queryResults = from c in db.CartItem.Include("Product")

                                       select c;

                    return queryResults.ToList();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al obtener items del carrito", e);
                }
        }

        public CartItem GetCartItemById(Guid cartItemId)
        {
            using (var db = new ESportDbContext())
                try
                {
                    var queryResults = from c in db.CartItem.Include("Product")
                                       where c.CartItemId.Equals(cartItemId)
                                       select c;
                    return queryResults.Single();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al obtener item del carrito ", e);
                }
        }

        public void RemoveEntity(CartItem entity)
        {
            using (var db = new ESportDbContext())
                try
                {
                    var cartItem = db.CartItem.Attach(entity);
                    db.CartItem.Remove(cartItem);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al remover item", e);
                }
        }

        public void UpdateEntity(CartItem entity)
        {
            using (var db = new ESportDbContext())
            {
                try
                {
                    var realCartItemToUpdate = db.CartItem.Attach(entity);
                    realCartItemToUpdate.Amount = entity.Amount;
                    realCartItemToUpdate.Quantity = entity.Quantity;
                    realCartItemToUpdate.PendingReview = entity.PendingReview;
                    realCartItemToUpdate.UnitPrice = entity.UnitPrice;
                    db.Entry(realCartItemToUpdate).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al actualizar item del carrito", e);
                }
            }
        }
    }
}
