using ESport.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESport.Repository.Stub.Test
{
    public class StubPointSystemConfigurationRepository : IPointSystemConfigurationRepository
    {
        private PointSystemConfiguration configuration;
        public void AddEntity(PointSystemConfiguration entity)
        {
            configuration=entity;
        }

        public List<PointSystemConfiguration> GetAllEntities()
        {
            List<PointSystemConfiguration> result = new List<PointSystemConfiguration>();
            if (configuration != null)
            {
                result.Add(configuration);
            }
            return result;
        }

        public PointSystemConfiguration GetByPropertyName(string propertyName)
        {
            if (configuration.PropertyName.Equals(propertyName))
            {
                return configuration;
            }
            throw new RepositoryException("No se encontró configuración para esta propiedad " + propertyName);
        }

        public void RemoveEntity(PointSystemConfiguration entity)
        {
            configuration = null;
        }

        public void UpdateEntity(PointSystemConfiguration entity)
        {
            configuration = entity;
        }
    }
}
