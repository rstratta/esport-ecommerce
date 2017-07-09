using System;
using System.Collections.Generic;

namespace ESport.Data.Commons
{
    public class ProductRequest
    {
        public string ProductId { get; set; }
        public string Factory { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public string FieldValue { get; set; }
        public List<ProductImageDTO> Images { get; set; }

        public List<FieldDTO> Filters { get; set; }
        public string ProductName { get; set; }
        public int AvailableStock { get; set; }
        public string CategoryId { get; set; }
        

        public ProductRequest()
        {
            Images = new List<ProductImageDTO>();
        }
    }


}
