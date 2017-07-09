using System.Collections.Generic;
using System.Windows.Forms;

using System;
using System.Xml;
using ESport.Product.Importer;
using System.IO;
using System.Xml.Serialization;

namespace ImportXml
{

    public class ImportXml : IProductImporter
    {
        private ICollection<ProductToImport> productRequestToImport;
        

        public ICollection<ProductToImport> LoadProducts()
        {
            productRequestToImport = new List<ProductToImport>();
            ImportXmlUI i = new ImportXmlUI(this);
            var answer = i.ShowDialog();

            if (answer == DialogResult.OK)
            {
                return productRequestToImport;
            }
            return new List<ProductToImport>();
        }

        public string GetImporterType()
        {
            return ESportImporterUtils.XML_PRODUCT_IMPORTER;
        }

        internal void ProcessFile(FileStream fileStream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(XmlProductFormater));
            XmlProductFormater productsToImport= (XmlProductFormater)serializer.Deserialize(fileStream);
            BuildResponse(productsToImport);
        }

        private void BuildResponse(XmlProductFormater productsToImport)
        {
            foreach (var xmlProduct in productsToImport.Products)
            {
                productRequestToImport.Add(BuildRequest(xmlProduct));
            }
        }

        private ProductToImport BuildRequest(XmlProductItemFormater xmlProduct)
        {
            ProductToImport product = new ProductToImport();
            product.ProductId = xmlProduct.ProductId;
            product.ProductName = xmlProduct.ProductName;
            product.Description = xmlProduct.Description;
            product.AvailableStock = xmlProduct.AvailableStock;
            product.CategetoryId = xmlProduct.CategetoryId;
            product.Factory = xmlProduct.Factory;
            product.Price = xmlProduct.Price;
            return product;
        }

        internal int GetQuantityLoaded()
        {
            return productRequestToImport.Count;
        }
    }
}
