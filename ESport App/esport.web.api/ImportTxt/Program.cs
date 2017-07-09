

using System;
using System.Windows.Forms;
using ESport.Data.Entities.ProductEntity;
using ESport.Data.Service;
using ESport.Data.Entities;
using ESport.Data.Repository;

namespace ImportTxt
{
    public class Program
    {
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ImportTxtUI(BuildTxtImporter()));
        }

        private static IProductImporter BuildTxtImporter()
        {
            IProductManager productManager = new ProductManager(new ProductRepository(), new FieldRepository());
            IProductService productService = new ProductServiceImpl(productManager, new SimpleProductDTOBuilder(new ImageDTOBuilder()), new FullProductDTOBuilder(new FieldDTOBuilder(), new ImageDTOBuilder()));
            IProductImporter productImporter = new ImportTxt(productService);
            return productImporter;
        }
    }
}
