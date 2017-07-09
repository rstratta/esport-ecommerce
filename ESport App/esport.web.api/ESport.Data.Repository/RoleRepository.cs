using ESport.Data.DataAccess;
using ESport.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ESport.Data.Repository
{
    public class RoleRepository : IRoleRepository
    {
        public void AddEntity(Role entity)
        {
            using (var db = new ESportDbContext())
                try
                {
                    db.Role.Add(entity);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al agregar rol al sistema", e);
                }
        }

        public List<Role> GetAllActiveRoles()
        {
            using (var db = new ESportDbContext())
                try
                {
                    var queryResults = from role in db.Role
                                       where role.Eliminated == false orderby role.RoleId 
                                       select role;

                    return queryResults.ToList();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al obtener roles activos", e);
                }
        }

        public List<Role> GetAllEntities()
        {
            using (var db = new ESportDbContext())
                try
                {
                    var queryResults = from role in db.Role
                                       orderby role.RoleId

                                       select role;

                    return queryResults.ToList();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al obtener roles", e);
                }
        }

        public Role GetRoleById(string roleId)
        {
            using (var db = new ESportDbContext())
                try
                {
                    var queryResults = from role in db.Role
                                       where role.RoleId.Equals(roleId)
                                       select role;
                    return queryResults.Single();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error obtener role " + roleId, e);
                }
        }

        public void RemoveEntity(Role entity)
        {
            using (var db = new ESportDbContext())
                try
                {
                    Role roleToRemove = db.Role.Single(role => role.RoleId == entity.RoleId);
                    roleToRemove.Eliminated = true;
                    db.Entry(roleToRemove).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al remover usuarios", e);
                }
        }

        public void UpdateEntity(Role entity)
        {
            using (var db = new ESportDbContext())
                try
                {
                    Role roleToUpdate = db.Role.Attach(entity);
                    roleToUpdate.Description = entity.Description;
                    roleToUpdate.Eliminated = false;
                    db.Entry(roleToUpdate).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al actualizar rol", e);
                }
        }


    }
}
