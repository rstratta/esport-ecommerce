using ESport.Data.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESport.Data.Entities
{
    public interface IPointSystemConfigurationManager
    {

        void AddConfiguration(PointSystemConfigurationDTO configurationDTO);
        List<PointSystemConfiguration> GetAllConfigurations();
        void RemoveConfiguration(PointSystemConfigurationDTO configurationDTO);
        void UpdateConfiguration(PointSystemConfigurationDTO configurationDTO);
        PointSystemConfiguration GetByPropertyName(string propertyName);
    }
}
