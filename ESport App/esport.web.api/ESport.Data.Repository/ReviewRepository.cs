using ESport.Data.DataAccess;
using ESport.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ESport.Data.Repository
{
    public class ReviewRepository : IReviewRepository
    {

        public List<Review> GetAllByProduct(Product productToReview)
        {
            using (var db = new ESportDbContext())
                try
                {
                    var queryResults = from r in db.Review.Include("User")
                                       where r.ProductId.Equals(productToReview.Id)
                                       select r;
                    return queryResults.ToList();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al obtener reviews del producto " + productToReview.ProductId, e);
                }
        }

        public List<Review> GetAllByUser(User userForReview)
        {
            using (var db = new ESportDbContext())
                try
                {
                    var queryResults = from r in db.Review.Include("Product").Include("User")
                                       where r.UserId.Equals(userForReview.Id)
                                       select r;
                    return queryResults.ToList();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al obtener reviews del producto " + userForReview.UserId, e);
                }
        }

        public void AddEntity(Review Review)
        {
            using (var db = new ESportDbContext())
                try
                {
                    db.Entry(Review.Product).State = EntityState.Unchanged;
                    db.Entry(Review.User).State = EntityState.Unchanged;
                    db.Review.Add(Review);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al agregar review al sistema", e);
                }
        }

        public Review GetReviewById(Guid Id)
        {
            using (var db = new ESportDbContext())
                try
                {
                    var queryResults = from r in db.Review.Include("Product").Include("User")
                                       where r.Id.Equals(Id)
                                       select r;
                    return queryResults.Single();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al obtener review " + Id, e);
                }
        }

        public List<Review> GetAllEntities()
        {
            using (var db = new ESportDbContext())
                try
                {
                    var queryResults = from r in db.Review.Include("Product").Include("User")

                                       select r;

                    return queryResults.ToList();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al obtener reviews", e);
                }
        }

        public void UpdateEntity(Review ReviewToUpdate)
        {
            using (var db = new ESportDbContext())
                try
                {
                    var realReviewToUpdate = db.Review.Attach(ReviewToUpdate);
                    realReviewToUpdate.Description = ReviewToUpdate.Description;
                    realReviewToUpdate.User = ReviewToUpdate.User;
                    realReviewToUpdate.Points = ReviewToUpdate.Points;
                    realReviewToUpdate.Product = ReviewToUpdate.Product;
                    realReviewToUpdate.ReviewDate = ReviewToUpdate.ReviewDate;
                    db.Entry(realReviewToUpdate).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al actualizar review", e);
                }
        }

        public void RemoveEntity(Review Review)
        {
            throw new RepositoryException("Error: operacion invalida para las reviews");
        }
    }
}
