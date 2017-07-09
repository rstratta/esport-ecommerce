using ESport.Data.DataAccess;
using ESport.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ESport.Data.Repository
{
    public class CartRepository : ICartRepository
    {
        public List<Cart> GetAllEntities()
        {
            using (var db = new ESportDbContext())
                try
                {
                    var queryResults = from c in db.Cart.Include("Items").Include("Items.Product")

                                       select c;

                    return queryResults.ToList();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al obtener carritos", e);
                }
        }

        public Cart GetCurrentCartByUser(User currentUser)
        {
            using (var db = new ESportDbContext())
                try
                {
                    var queryResults = from c in db.Cart.Include("Items").Include("Items.Product")
                                       where c.User.UserId.Equals(currentUser.UserId) && (c.State.Equals(Cart.INIT_CART) || c.State.Equals(Cart.PENDING_CART))
                                       select c;
                    return queryResults.Single();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al obtener carrito del usuario " + currentUser.UserId, e);
                }
        }
        public List<CartItem> AllCartItemsPendingOfReview(User user)
        {
            using (var db = new ESportDbContext())
                try
                {
                    var queryResults = from c in db.Cart.Include("Items").Include("Items.Product")
                                       where c.User.UserId.Equals(user.UserId) && c.State.Equals(Cart.FINISHED_CART)
                                       select c;
                    return BuildCartItemListResult(queryResults.ToList());
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al obtener items sin reviews del usuario " + user.UserId, e);
                }
        }

        private List<CartItem> BuildCartItemListResult(ICollection<Cart> list)
        {
            List<CartItem> result = new List<CartItem>();
            foreach(Cart cart in list) { 
                foreach (var cartItem in cart.Items)
                {
                    if (cartItem.PendingReview)
                    {
                        result.Add(cartItem);
                    }
                }
            }
            return result;
        }

        public List<Cart> GetAllCartsByUser(User user)
        {
            using (var db = new ESportDbContext())
                try
                {
                    var queryResults = from c in db.Cart.Include("User").Include("Items").Include("Items.Product")
                                       where c.User.UserId.Equals(user.UserId) && c.State.Equals(Cart.FINISHED_CART)
                                       orderby c.Opendate descending
                                       select c;
                    return queryResults.ToList();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al obtener carrito del usuario " + user.UserId, e);
                }
        }


        public void AddEntity(Cart cart)
        {
            using (var db = new ESportDbContext())
                try
                {
                    if (cart.User != null)
                        db.Entry(cart.User).State = EntityState.Unchanged;
                    IgnoreProducts(db, cart.Items);
                    db.Cart.Add(cart);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al agregar carrito al sistema", e);
                }
        }

        private void IgnoreProducts(ESportDbContext db, ICollection<CartItem> items)
        {
            foreach (CartItem item in items)
            {
                db.Entry(item.Product).State = EntityState.Unchanged;
            }
        }

        public void UpdateEntity(Cart cartToUpdate)
        {

            using (var db = new ESportDbContext())
            {
                try
                {
                    var realCartToUpdate = db.Cart.Attach(cartToUpdate);
                    realCartToUpdate.DeliveryAddress = cartToUpdate.DeliveryAddress;
                    realCartToUpdate.DeliveryPhone = cartToUpdate.DeliveryPhone;
                    realCartToUpdate.Total = cartToUpdate.Total;
                    realCartToUpdate.Items = cartToUpdate.Items;
                    realCartToUpdate.State = cartToUpdate.State;
                    db.Entry(realCartToUpdate).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al actualizar carrito", e);
                }
            }
        }



        public void RemoveEntity(Cart Cart)
        {
            throw new RepositoryException("Error: operacion invalida para los carritos");
        }

        public ICollection<ProductReportRow> GetMaxProductSaled(int quantity)
        {
           using (var db = new ESportDbContext())
                    try
                    {
                    return db.Database.SqlQuery<ProductReportRow>("select top(" + quantity + ")  p.ProductId as productId, p.Description, sum(ciResult.Quantity) as quantity from products p inner " +
                        "join (select CONVERT(uniqueidentifier, ci.ProductId) as productId, ci.Quantity from CartItems ci inner join  (select *from carts where State = 'F')ca on " +
                                "CONVERT(uniqueidentifier, ci.Cart_CartId) = CONVERT(uniqueidentifier, ca.CartId))ciResult on CONVERT(uniqueidentifier, p.Id) = ciResult.ProductId " +
                                    "group by p.Description, p.ProductId order by quantity desc").ToList();

                    }
                    catch (Exception e)
                    {
                        throw new RepositoryException("Error al obtener reporte de  producto", e);
                    }
            }

        public ICollection<CategoryReportRow> GetCategoryReport(DateTime startDate, DateTime endDate)
        {
            using (var db = new ESportDbContext())
                try
                {
                    string query = "select cat.Description as CategoryReport, " +
                        "round(100 * (sum(prodResult.amount) / (select sum(cartItem1.Amount) amount from CartItems cartItem1 " +
                        "inner join (select c.cartId from carts c where c.state = 'F' and c.opendate>='" + FormatDate(startDate) +
                        "' and c.opendate<='" + FormatDate(endDate) + "')cart1 on CONVERT(uniqueidentifier, cartItem1.Cart_CartId) = CONVERT(uniqueidentifier, cart1.CartId))),0) as AVGReport , " +
                        "sum(prodResult.amount) as AmountReport from Categories cat inner join (select p.Category_Id as categoryId, ciResult.amount as amount from products p inner " +
                        "join (select CONVERT(uniqueidentifier, ci.ProductId) as productId, ci.amount as amount from CartItems ci inner join  (select * from carts where State = 'F' and opendate>='" + FormatDate(startDate) +
                        "' and opendate<='" + FormatDate(endDate) + "')ca on " +
                        "CONVERT(uniqueidentifier, ci.Cart_CartId) = CONVERT(uniqueidentifier, ca.CartId))ciResult on CONVERT(uniqueidentifier, p.Id) = ciResult.ProductId)prodResult " +
                        "on CONVERT(uniqueidentifier, cat.id) = CONVERT(uniqueidentifier, prodResult.categoryId) " +
                        " group by cat.Description order  by AVGReport desc";
                    return db.Database.SqlQuery<CategoryReportRow>(query).ToList();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al obtener reporte de categorias", e);
                }
        }

        private string FormatDate(DateTime date)
        {
            return date.Year + "/" + date.Month + "/" + date.Day + " " + date.Hour + ":" + date.Minute + ":" + date.Second;
        }
    }
}
