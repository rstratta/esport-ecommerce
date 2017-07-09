using ESport.Data.DataAccess;
using ESport.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ESport.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private static string ORDER_BY = "orderByFilter";
        private static string ORDER_BY_OP = "orderByOperation";

        public List<Product> GetAllEntities()
        {
            using (var db = new ESportDbContext())
                try
                {
                    var queryResults = from p in db.Product.Include("Category").Include("Fields").Include("Fields.Field").Include("Images")

                                       select p;

                    return queryResults.ToList();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al obtener productos", e);
                }
        }

        public void AddEntity(Product Product)
        {
            using (var db = new ESportDbContext())
                try
                {
                    if (Product.Category != null)
                        db.Entry(Product.Category).State = EntityState.Unchanged;
                    db.Product.Add(Product);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al agregar producto al sistema", e);
                }
        }

        public Product GetProductById(String ProductId)
        {
            using (var db = new ESportDbContext())
                try
                {
                    var queryResults = from p in db.Product.Include("Category").Include("Fields").Include("Fields.Field").Include("Images")
                                       where p.ProductId.Equals(ProductId)
                                       select p;
                    return queryResults.Single();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al obtener producto " + ProductId, e);
                }
        }

        public List<Product> GetAllActiveProducts()
        {
            using (var db = new ESportDbContext())
                try
                {
                    var queryResults = from p in db.Product.Include("Category").Include("Fields").Include("Fields.Field").Include("Images")
                                       where p.Eliminated == false
                                       select p;

                    return queryResults.ToList();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al obtener productos activos", e);
                }
        }

        public void UpdateEntity(Product ProductToUpdate)
        {
            using (var db = new ESportDbContext())
                try
                {
                    var realProductToUpdate = db.Product.Attach(ProductToUpdate);
                    realProductToUpdate.Description = ProductToUpdate.Description;
                    realProductToUpdate.ProductName = ProductToUpdate.ProductName;
                    realProductToUpdate.Factory = ProductToUpdate.Factory;
                    realProductToUpdate.Fields = ProductToUpdate.Fields;
                    realProductToUpdate.Images = ProductToUpdate.Images;
                    realProductToUpdate.Price = ProductToUpdate.Price;
                    realProductToUpdate.AvailableStock = ProductToUpdate.AvailableStock;
                    realProductToUpdate.BlackProduct = ProductToUpdate.BlackProduct;
                    realProductToUpdate.ReviewAverage = ProductToUpdate.ReviewAverage;
                    db.Entry(realProductToUpdate).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                       
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al actualizar producto", e);
                }
            if (ProductToUpdate.Category != null)
            {
                using (var db = new ESportDbContext())
                    try
                    {
                        db.Configuration.LazyLoadingEnabled = false;
                        var product = db.Product.Single(prod => prod.Id == ProductToUpdate.Id);
                        var category = db.Category.Single(cat => cat.Id == ProductToUpdate.Category.Id);
                        product.Category = category;
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        throw new RepositoryException("Error al actualizar categoria en producto", e);
                    }
            }
        }

        public void RemoveEntity(Product Product)
        {
            using (var db = new ESportDbContext())
                try
                {
                    Product realProductToRemove = db.Product.Single(p => p.ProductId == Product.ProductId);
                    realProductToRemove.Eliminated = true;
                    db.Entry(realProductToRemove).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al remover producto", e);
                }
        }

        public List<Product> GetAllProductsByCategoryId(string categoryId)
        {
            using (var db = new ESportDbContext())
                try
                {
                    var queryResults = from prod in db.Product.Include("Fields").Include("Fields.Field").Include("Images")
                                       where prod.Eliminated == false && prod.Category.CategoryId == categoryId
                                       select prod;

                    return queryResults.ToList();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al obtener productos por categoria", e);
                }
        }

        public void RemoveFieldFromProduct(ProductFields productField)
        {
            using (var db = new ESportDbContext())
                try
                {
                    var entityToRemove = db.ProductFields.Attach(productField);
                    db.ProductFields.Remove(entityToRemove);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al eliminar campo en producto", e);
                }
        }

        public void AddFieldInProduct(ProductFields productField)
        {
            using (var db = new ESportDbContext())
                try
                {
                    if (productField.Product != null)
                        db.Entry(productField.Product).State = EntityState.Unchanged;
                    if (productField.Field != null)
                        db.Entry(productField.Field).State = EntityState.Unchanged;
                    db.ProductFields.Add(productField);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al agregar campo en producto", e);
                }
        }

        public void UpdateProductField(ProductFields productField)
        {
            using (var db = new ESportDbContext())
                try
                {
                    var entityToUpdate = db.ProductFields.Attach(productField);
                    entityToUpdate.Value = productField.Value;
                    db.Entry(entityToUpdate).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al eliminar campo en producto", e);
                }
        }

        public List<Product> GetProductsByFIlters(List<Filter> filters)
        {
            List<Product> sqlResult;
            List<Product> result = new List<Product>();
            if (filters.Count == 0)
            {
                return GetAllActiveProducts();
            }
            else
            {
                using (var db = new ESportDbContext())
                    try
                    {
                        db.Configuration.LazyLoadingEnabled = false;
                        sqlResult= db.Product.SqlQuery(GetSQLQueryFromFilters(filters)).ToList();
                        
                    }
                    catch (Exception e)
                    {
                        throw new RepositoryException("Error al eliminar campo en producto", e);
                    }
                foreach (var product in sqlResult)
                {
                    result.Add(GetProductById(product.ProductId));
                }
                    return result;
            }
        }

        private string GetSQLQueryFromFilters(List<Filter> filters)
        {
            string query = "select * from products ";
            return query +GetWhere(filters) +GetOrder(filters);
        }

        private string GetWhere(List<Filter> filters)
        {
            string where = "where eliminated=0 ";
            string whereFilters = "";
            if (filters.Count > 0)
            {
                Filter last = filters.Last();
                foreach (Filter filter in filters)
                {
                    if(!IsOrderByFilter(filter))
                    {
                        whereFilters += filter.FilterName + " like '%" + filter.FilterValue + "%' ";
                        if (!filter.Equals(last) && !IsOrderByFilter(last))
                        {
                            whereFilters += " or ";
                        }
                    }

                }
            }
            if (!String.IsNullOrWhiteSpace(whereFilters))
            {
                where += " and "+whereFilters;
            }
            return where;
        }

        private bool IsOrderByFilter(Filter filter)
        {
            return filter.FilterName.Equals(ORDER_BY) || filter.FilterName.Equals(ORDER_BY_OP);
        }

        private string GetOrder(List<Filter> filters)
        {
            string orderBy = "";
            if (filters.Count > 0)
            {
                Filter orderByFilter=filters.Find(fil => fil.FilterName == ORDER_BY);
                Filter orderByOp= filters.Find(fil => fil.FilterName == ORDER_BY_OP);
                if (orderByFilter != null)
                {
                    orderBy = " order by " + orderByFilter.FilterValue + " ";
                    if (orderByOp != null)
                    {
                        orderBy += orderByOp.FilterValue;
                    }
                }
            }
            return orderBy;
        }

        public void RemoveImageFromProduct(ProductImage productImage)
        {
            using (var db = new ESportDbContext())
                try
                {
                    var entityToRemove = db.ProductImages.Attach(productImage);
                    db.ProductImages.Remove(entityToRemove);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al eliminar imagen en producto", e);
                }
        }

        public void AddImageInProduct(ProductImage productImage)
        {
            using (var db = new ESportDbContext())
                try
                {
                    if (productImage.Product != null)
                        db.Entry(productImage.Product).State = EntityState.Unchanged;
                    db.ProductImages.Add(productImage);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al agregar imagen en producto", e);
                }
        }

        public List<Field> GetNotUseFieldsByProdyct(Product product)
        {
            List<Field> allFields = new List<Field>();
            using (var db = new ESportDbContext())
                try
                {
                    allFields= db.Field.ToList();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al obtener campos no utilizados", e);
                }
            List<Field> result = new List<Field>();
            foreach (var field in allFields)
            {
                if (product.Fields.Where(prodField => prodField.Field.Equals(field)).ToList().Count == 0)
                {
                    result.Add(field);
                }
            }
            return result;          
        }

      
    }
}
