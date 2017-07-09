using ESport.Data.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESport.Data.Service
{
    public interface IPointSystemConfigurationService
    {
        void SavePointSystemCongirutraion(PointSystemConfigurationDTO configuration);

        PointSystemConfigurationDTO GetPointSystemConfiguration();
    }
}
