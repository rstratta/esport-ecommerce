using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESport.Data.Entities
{
    public interface IPointSystemConfigurationRepository : IRepository<PointSystemConfiguration>
    {
        PointSystemConfiguration GetByPropertyName(string propertyName);
    }
}
