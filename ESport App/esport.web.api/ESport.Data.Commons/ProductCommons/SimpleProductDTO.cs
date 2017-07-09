using System.Collections.Generic;

namespace ESport.Data.Commons
{
    public class SimpleProductDTO
    {
        public string Description { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string ProductId { get; set; }
        public double ReviewAverage { get; set; }
        public List<ProductImageDTO> Images { get; set; }
        public string Factory { get; set; }
        public int AvailableStock { get; set; }
        public bool BlackProduct { get; set; }
    }
}
