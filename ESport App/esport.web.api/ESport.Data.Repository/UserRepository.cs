using ESport.Data.DataAccess;
using ESport.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ESport.Data.Repository
{
    public class UserRepository : IUserRepository
    {

        public void AddEntity(User User)
        {
            using (var db = new ESportDbContext())
                try
                {
                    foreach (var item in User.Roles)
                    {
                        db.Entry(item).State = EntityState.Unchanged;
                    }
                    db.User.Add(User);
                    db.SaveChanges();

                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al agregar usuario al sistema", e);
                }
        }

        public User GetUserById(String UserId)
        {
            using (var db = new ESportDbContext())
                try
                {
                    var queryResults = from u in db.User.Include("Roles")
                                       where u.UserId.Equals(UserId)
                                       select u;
                    return queryResults.Single();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error obtener usuario " + UserId, e);
                }
        }

        public List<User> GetAllActiveUsers()
        {
            using (var db = new ESportDbContext())
                try
                {
                    var queryResults = from u in db.User.Include("Roles")
                                       where u.Eliminated == false
                                       select u;

                    return queryResults.ToList();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al obtener usuarios activos", e);
                }
        }

        public List<User> GetAllEntities()
        {
            using (var db = new ESportDbContext())
                try
                {
                    var queryResults = from u in db.User.Include("Roles")

                                       select u;

                    return queryResults.ToList();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al obtener usuarios", e);
                }
        }

        public void UpdateEntity(User UserToUpdate)
        {
            using (var db = new ESportDbContext())
                try
                {
                    var realUserToUpdate = db.User.Attach(UserToUpdate);
                    realUserToUpdate.UserName = UserToUpdate.UserName;
                    realUserToUpdate.UserLastName = UserToUpdate.UserLastName;
                    realUserToUpdate.Password = UserToUpdate.Password;
                    realUserToUpdate.Address = UserToUpdate.Address;
                    realUserToUpdate.EMail = UserToUpdate.EMail;
                    realUserToUpdate.Phone = UserToUpdate.Phone;
                    realUserToUpdate.Roles = UserToUpdate.Roles;
                    realUserToUpdate.Points = UserToUpdate.Points;
                    db.Entry(realUserToUpdate).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al actualizar usuarios", e);
                }
        }

        public void RemoveEntity(User User)
        {
            using (var db = new ESportDbContext())
                try
                {
                    User realUserToRemove = db.User.Single(t => t.UserId == User.UserId);
                    realUserToRemove.Eliminated = true;
                    db.Entry(realUserToRemove).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al remover usuarios", e);
                }
        }

        public void RemoveRoleFromUser(User currentUser, Role roleToRemove)
        {
            using (var db = new ESportDbContext())
                try
                {
                    var user = (from u in db.User
                                    select u).FirstOrDefault(u => u.Id.Equals(currentUser.Id));
                    var role = (from r in db.Role
                                   select r).FirstOrDefault(r => r.Id.Equals(roleToRemove.Id));
                    user.Roles.Remove(role);
                    db.User.Attach(user);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al eliminar rol en usuario", e);
                }
        }

        public void AddRoleInUser(User currentUser, Role roleToAdd)
        {
            using (var db = new ESportDbContext())
                try
                {
                    var user = (from u in db.User
                                    select u).FirstOrDefault(us => us.Id.Equals(currentUser.Id));
                    var role = (from r in db.Role
                                   select r).FirstOrDefault(r => r.Id.Equals(roleToAdd.Id));
                    user.Roles.Add(role);
                    db.User.Attach(user);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al agregar rol al usuario", e);
                }
        }

    }
}