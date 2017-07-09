using ESport.Data.DataAccess;
using ESport.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ESport.Data.Repository
{
    public class FieldRepository : IFieldRepository
    {
        public void AddEntity(Field entity)
        {
            using (var db = new ESportDbContext())
                try
                {
                    db.Field.Add(entity);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al agregar campo al sistema", e);
                }
        }

        public List<Field> GetAllActiveFields()
        {
            return GetAllEntities();
        }

        public List<Field> GetAllEntities()
        {
            using (var db = new ESportDbContext())
            {
                try
                {
                    var queryResults = from f in db.Field

                                       select f;
                    return queryResults.ToList();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al obtener campos", e);
                }
            }
        }

        public Field GetFieldByName(string fieldName)
        {
            using (var db = new ESportDbContext())
            {
                try
                {
                    var queryResults = from f in db.Field
                                       where f.Name.Equals(fieldName)
                                       select f;
                    return queryResults.First();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al obtener campo", e);
                }
            }
        }

        public void RemoveEntity(Field entity)
        {
            throw new RepositoryException("Operación invalida para campos");
        }

        public void UpdateEntity(Field entity)
        {
            throw new RepositoryException("Operación invalida para campos");
        }
    }
}
