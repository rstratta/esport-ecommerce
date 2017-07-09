using ESport.Data.DataAccess;
using ESport.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ESport.Data.Repository
{
    public class UserContextRepository : IUserContextRepository
    {
        public void AddEntity(UserContext entity)
        {
            using (var db = new ESportDbContext())
                try
                {
                    db.UserContext.Add(entity);
                    db.SaveChanges();

                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al guardar contexto de usuario en sistema", e);
                }
        }

        public List<UserContext> GetAllEntities()
        {
            using (var db = new ESportDbContext())
                try
                {
                    var queryResults = from usContext in db.UserContext

                                       select usContext;

                    return queryResults.ToList();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al obtener contexto de usuarios", e);
                }
        }

        public UserContext GetUserContextByToken(Guid Token)
        {
            using (var db = new ESportDbContext())
                try
                {
                    var queryResults = from u in db.UserContext
                                       where u.Token.Equals(Token)
                                       select u;
                    return queryResults.Single();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error obtener contexto de usuario " , e);
                }
        }

        public UserContext GetUserContextByUserId(string userId)
        {
            using (var db = new ESportDbContext())
                try
                {
                    var queryResults = from u in db.UserContext
                                       where u.UserId.Equals(userId)
                                       select u;
                    return queryResults.Single();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error obtener contexto de usuario ", e);
                }
        }

        public void RemoveEntity(UserContext entity)
        {
            using (var db = new ESportDbContext())
                try
                {
                    var entityToRemove = db.UserContext.Attach(entity);
                    db.UserContext.Remove(entityToRemove);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al eliminar contexto de usuario", e);
                }
        }

        public void UpdateEntity(UserContext entity)
        {
            using (var db = new ESportDbContext())
                try
                {
                    var userContext = db.UserContext.Attach(entity);
                    userContext.SerializedContext = entity.SerializedContext;
                    db.Entry(userContext).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al actualizar contexto de usuario", e);
                }
        }
    }
}
