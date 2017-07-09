
using ESport.Product.Importer;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ImportTxt
{
    public class ImportTxt : IProductImporter
    {
        private ICollection<ProductToImport> productRequestToImport;
        public string GetImporterType()
        {
            return ESportImporterUtils.TXT_PRODUCT_IMPORTER;
        }

      

        public ICollection<ProductToImport> LoadProducts()
        {
            productRequestToImport = new List<ProductToImport>();
            ImportTxtUI txtImporter = new ImportTxtUI(this);
            var answer = txtImporter.ShowDialog();
            if (answer == DialogResult.OK)
            {
                return productRequestToImport;
            }
            return new List<ProductToImport>();
        }

        internal void ProcessLine(string line)
        {
            string[] product = line.Split('|');
            if (product.Length == 7)
            {
                ValidateFields(product);
                ProductToImport request = new ProductToImport();
                request.ProductId= product[0];
                request.ProductName= product[1];
                request.Description= product[2];
                request.Factory= product[3];
                request.Price = Convert.ToDouble(product[4]);
                request.AvailableStock = Convert.ToInt32(product[5]);
                request.CategetoryId= product[6];
                productRequestToImport.Add(request);
            }
            else
            {
                throw new FormatException("Formato incorrecto en línea " + line + ".");
            }
        }

        private void ValidateFields(string[] product)
        {
            ValidateStringField(product[0], "ProductId");
            ValidateStringField(product[1], "ProductName");
            ValidateStringField(product[2], "Description");
            ValidateStringField(product[3], "Factory");
            ValidateNumberFields(product[4], "Price");
            ValidateNumberFields(product[5], "AvailableStock");
            ValidateStringField(product[6], "CategoryId");


        }

        private void ValidateStringField(string field,  string fieldName)
        {
            if (String.IsNullOrWhiteSpace(field))
            {
                throw new  FormatException("El campo " + fieldName + " no puede ser vacio");
            }
        }

        private void ValidateNumberFields(string field, string fieldName)
        {
            double testParse = 0;
            bool testConvert = double.TryParse(field, out testParse);
            if (!testConvert)
            {
                throw new FormatException("El campo " +fieldName +" debe ser númerico");
            }
        }

        internal int GetQuantityLoaded()
        {
            return productRequestToImport.Count;
        }
    }
}
