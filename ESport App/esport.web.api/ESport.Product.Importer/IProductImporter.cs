using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESport.Product.Importer
{
    public interface IProductImporter
    {
        ICollection<ProductToImport> LoadProducts();

        string GetImporterType();
    }
}
