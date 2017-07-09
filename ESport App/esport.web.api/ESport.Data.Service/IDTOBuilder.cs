using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESport.Data.Service
{
    public interface IDTOBuilder<D, E>
    {
        D buildDTO(E entity);
    }
}
