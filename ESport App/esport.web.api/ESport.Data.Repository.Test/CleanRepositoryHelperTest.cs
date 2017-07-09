using ESport.Data.DataAccess;
using ESport.Data.Entities;
using System;

namespace ESport.Data.Repository.Test
{
    public class CleanRepositoryHelperTest
    {
        public static void CleanDB()
        {
            CleanCartItem(new CartItemRepository());
            CleanReview(new ReviewRepository());
            CleanCart(new CartRepository());
            CleanProduct(new ProductRepository());
            CleanCategories(new CategoryRepository());
            CleanUsers(new UserRepository());
            CleanRoles(new RoleRepository());
        }

        private static void CleanRoles(RoleRepository repository)
        {
            var entities = repository.GetAllEntities();
            foreach (Role entity in entities)
            {
                using (var db = new ESportDbContext())
                    try
                    {
                        var entityToRemove = db.Role.Attach(entity);
                        db.Role.Remove(entityToRemove);
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        throw new RepositoryException("Error al eliminar entidad", e);
                    }
            }
        }

        private static void CleanProduct(ProductRepository repository)
        {
            var entities = repository.GetAllEntities();
            foreach (Product entity in entities)
            {
                using (var db = new ESportDbContext())
                    try
                    {
                        var entityToRemove = db.Product.Attach(entity);
                        db.Product.Remove(entityToRemove);
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        throw new RepositoryException("Error al eliminar entidad", e);
                    }
            }
        }

        private static void CleanCategories(CategoryRepository repository)
        {
            var entities = repository.GetAllEntities();
            foreach (Category entity in entities)
            {
                using (var db = new ESportDbContext())
                    try
                    {
                        var entityToRemove = db.Category.Attach(entity);
                        db.Category.Remove(entityToRemove);
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        throw new RepositoryException("Error al eliminar entidad", e);
                    }
            }
        }

        private static void CleanUsers(UserRepository repository)
        {
            var entities = repository.GetAllEntities();
            foreach (User entity in entities)
            {
                using (var db = new ESportDbContext())
                    try
                    {
                        var entityToRemove = db.User.Attach(entity);
                        db.User.Remove(entityToRemove);
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        throw new RepositoryException("Error al eliminar entidad", e);
                    }
            }
        }

        private static void CleanCart(CartRepository repository)
        {
            var entities = repository.GetAllEntities();
            foreach (Cart entity in entities)
            {
               
                using (var db = new ESportDbContext())
                    try
                    {
                        var entityToRemove = db.Cart.Attach(entity);
                        db.Cart.Remove(entityToRemove);
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        throw new RepositoryException("Error al eliminar entidad", e);
                    }
            }
        }

        private static void CleanCartItem(CartItemRepository repository)
        {
            var entities = repository.GetAllEntities();
            foreach (CartItem entity in entities)
            {

                using (var db = new ESportDbContext())
                    try
                    {
                        var entityToRemove = db.CartItem.Attach(entity);
                        db.CartItem.Remove(entityToRemove);
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        throw new RepositoryException("Error al eliminar entidad", e);
                    }
            }
        }

        private static void CleanReview(ReviewRepository repository)
        {
            var entities = repository.GetAllEntities();
            foreach (Review entity in entities)
            {
                using (var db = new ESportDbContext())
                    try
                    {
                        var entityToRemove = db.Review.Attach(entity);
                        db.Review.Remove(entityToRemove);
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        throw new RepositoryException("Error al eliminar entidad", e);
                    }
            }
        }
       
    }
}
