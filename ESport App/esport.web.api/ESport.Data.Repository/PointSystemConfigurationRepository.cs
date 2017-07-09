using ESport.Data.DataAccess;
using ESport.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESport.Data.Repository
{
    public class PointSystemConfigurationRepository : IPointSystemConfigurationRepository
    {
        public List<PointSystemConfiguration> GetAllEntities()
        {
            using (var db = new ESportDbContext())
                try
                {
                    var queryResults = from c in db.PointSystemConfigurations

                                       select c;

                    return queryResults.ToList();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al obtener configuraciones", e);
                }
        }

        public void AddEntity(PointSystemConfiguration configuration)
        {
            using (var db = new ESportDbContext())
                try
                {
                    db.PointSystemConfigurations.Add(configuration);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al agregar configuración al sistema", e);
                }
        }

        public void UpdateEntity(PointSystemConfiguration configuration)
        {

            using (var db = new ESportDbContext())
            {
                try
                {
                    var confToUpdate = db.PointSystemConfigurations.Attach(configuration);
                    confToUpdate.PropertyValue = configuration.PropertyValue;
                    db.Entry(confToUpdate).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error al actualizar configuración", e);
                }
            }
        }



        public void RemoveEntity(PointSystemConfiguration configuration)
        {
            throw new RepositoryException("Error: operacion invalida para las configuraciones");
        }

        public PointSystemConfiguration GetByPropertyName(String propertyName)
        {
            using (var db = new ESportDbContext())
                try
                {
                    var queryResults = from c in db.PointSystemConfigurations
                                       where c.PropertyName.Equals(propertyName)
                                       select c;
                    return queryResults.Single();
                }
                catch (Exception e)
                {
                    throw new RepositoryException("Error obtener propiedad  " + propertyName, e);
                }
        }
    }
}
