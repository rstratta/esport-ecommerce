using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESport.Product.Importer
{
    public class ProductToImport
    {
        public string ProductId { get; set; }
        public string Factory { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ProductName { get; set; }
        public int AvailableStock { get; set; }
        public string CategetoryId { get; set; }
    }
}
