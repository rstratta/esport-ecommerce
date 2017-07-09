using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESport.Data.Commons;
using ESport.Data.Entities;

namespace ESport.Data.Service.PointSystem
{
    public class PointSystemConfigurationService : IPointSystemConfigurationService
    {
        private IPointSystemConfigurationManager pointSystemManager;

        public PointSystemConfigurationService(IPointSystemConfigurationManager pointSystemManager)
        {
            this.pointSystemManager = pointSystemManager;
        }
        public PointSystemConfigurationDTO GetPointSystemConfiguration()
        {
            PointSystemConfiguration result= pointSystemManager.GetByPropertyName(ESportUtils.LOYALTY_PROPERTY_NAME);
            return new PointSystemConfigurationDTO() { PropertyName = result.PropertyName, PropertyValue = result.PropertyValue };
        }

        public void SavePointSystemCongirutraion(PointSystemConfigurationDTO configuration)
        {
            ValidateRequest(configuration);
            try
            {
                pointSystemManager.AddConfiguration(configuration);
            }catch(OperationException)
            {
                pointSystemManager.UpdateConfiguration(configuration);
            }
        }

        private void ValidateRequest(PointSystemConfigurationDTO configuration)
        {
            if (String.IsNullOrWhiteSpace(configuration.PropertyName))
            {
                throw new OperationException("El nombre de la propiedad es necesario");
            }

        }
    }
}
