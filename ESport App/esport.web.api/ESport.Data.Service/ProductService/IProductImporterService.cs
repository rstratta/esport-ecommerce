using ESport.Data.Commons;
using System.Collections.Generic;

namespace ESport.Data.Service
{
    public  interface IProductImporterService : IObservable
    {
        void ImportProducts(ICollection<ProductRequest> productsToImport, UserDTO userDTO);
    }
}
