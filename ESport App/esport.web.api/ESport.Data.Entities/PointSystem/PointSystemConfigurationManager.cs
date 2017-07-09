using System.Collections.Generic;
using ESport.Data.Commons;

namespace ESport.Data.Entities
{
    public class PointSystemConfigurationManager : IPointSystemConfigurationManager
    {
        public IPointSystemConfigurationRepository pointSystemConfiguration;
        public PointSystemConfigurationManager(IPointSystemConfigurationRepository pointSystemConfiguration)
        {
            this.pointSystemConfiguration = pointSystemConfiguration;
        }
        public void AddConfiguration(PointSystemConfigurationDTO configurationDTO)
        {
            try
            {
                pointSystemConfiguration.AddEntity(BuildConfigurationFromDTO(configurationDTO));
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message, e);
            }

        }

        public List<PointSystemConfiguration> GetAllConfigurations()
        {
            return pointSystemConfiguration.GetAllEntities();
        }

        public PointSystemConfiguration GetByPropertyName(string propertyName)
        {
            return pointSystemConfiguration.GetByPropertyName(propertyName);
        }

        public void RemoveConfiguration(PointSystemConfigurationDTO configurationDTO)
        {
            PointSystemConfiguration configurationToRemove = pointSystemConfiguration.GetByPropertyName(configurationDTO.PropertyName);
            pointSystemConfiguration.RemoveEntity(configurationToRemove);
        }

        public void UpdateConfiguration(PointSystemConfigurationDTO configurationDTO)
        {
            try
            {
                PointSystemConfiguration configurationToUpdate = pointSystemConfiguration.GetByPropertyName(configurationDTO.PropertyName);
                configurationToUpdate.PropertyValue = configurationDTO.PropertyValue;
                pointSystemConfiguration.UpdateEntity(configurationToUpdate);
            }
            catch (RepositoryException e)
            {
                throw new OperationException(e.Message, e);
            }
        }

        private PointSystemConfiguration BuildConfigurationFromDTO(PointSystemConfigurationDTO configurationDTO)
        {
            PointSystemConfiguration configuration = new PointSystemConfiguration();
            configuration.PropertyName = configurationDTO.PropertyName;
            configuration.PropertyValue = configurationDTO.PropertyValue;
            return configuration;
        }
    }
}
