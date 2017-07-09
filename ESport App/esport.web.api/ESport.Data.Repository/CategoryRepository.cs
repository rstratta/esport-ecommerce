using ESport.Data.DataAccess;
using ESport.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ESport.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        public void AddEntity(Category Category)
        {
            using (var db = new ESportDbContext())
                try
                {
                    db.Category.Add(Category);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al agregar categoria al sistema", e);
                }
        }

        public Category GetCategoryById(String CategoryId)
        {
            using (var db = new ESportDbContext())
                try
                {
                    var queryResults = from c in db.Category.Include("Products").Include("Products.Images").Include("Products.Fields")
                                       where c.CategoryId.Equals(CategoryId)
                                       select c;
                    return queryResults.Single();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al obtener categoria " + CategoryId, e);
                }
        }

        public List<Category> GetAllActiveCategories()
        {
            using (var db = new ESportDbContext())
                try
                {
                    var queryResults = from c in db.Category.Include("Products").Include("Products.Images").Include("Products.Fields").Include("Products.Fields.Field")
                                       where c.Eliminated == false
                                       select c;

                    return queryResults.ToList();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al obtener categorias activas", e);
                }
        }

        public List<Category> GetAllEntities()
        {
            using (var db = new ESportDbContext())
                try
                {
                    var queryResults = from c in db.Category.Include("Products").Include("Products.Images").Include("Products.Fields").Include("Products.Fields.Field")

                                       select c;

                    return queryResults.ToList();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al obtener categorias", e);
                }
        }

        public void UpdateEntity(Category CategoryToUpdate)
        {
            using (var db = new ESportDbContext())
                try
                {
                    var realCategoryToUpdate = db.Category.Attach(CategoryToUpdate);
                    realCategoryToUpdate.Description = CategoryToUpdate.Description;
                    realCategoryToUpdate.Products = CategoryToUpdate.Products;
                    db.Entry(realCategoryToUpdate).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al actualizar categoria", e);
                }
        }

        public void RemoveEntity(Category Category)
        {
            using (var db = new ESportDbContext())
                try
                {
                    Category realCategoryToRemove = db.Category.Single(t => t.CategoryId == Category.CategoryId);
                    realCategoryToRemove.Eliminated = true;
                    db.Entry(realCategoryToRemove).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al remover categoria", e);
                }
        }

        public void RemoveProductFromCategory(Category currentCategory, Product productToRemove)
        {
            using (var db = new ESportDbContext())
                try
                {
                    var category = (from c in db.Category
                                    select c).FirstOrDefault(c => c.Id.Equals(currentCategory.Id));
                    var product = (from p in db.Product
                                   select p).FirstOrDefault(p => p.Id.Equals(productToRemove.Id));
                    category.Products.Remove(product);
                    db.Category.Attach(category);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al actualizar categoria", e);
                }
        }

        public void AddProductOnCategory(Category currentCategory, Product productToAdd)
        {
            using (var db = new ESportDbContext())
                try
                {
                    var category = (from c in db.Category
                                 select c).FirstOrDefault(c => c.Id.Equals(currentCategory.Id));
                    var product = (from p in db.Product
                                 select p).FirstOrDefault(p => p.Id.Equals(productToAdd.Id));
                    category.AddProduct(product);
                    db.Category.Attach(category);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al actualizar categoria", e);
                }
        }
    }
}