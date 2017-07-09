using System.Collections.Generic;

namespace ESport.Data.Commons
{

    public class CategoryDTO
    {
        public string CategoryId { get; set; }
        public string Description { get; set; }
        public bool Eliminated { get; set; }
        public List<FullProductDTO> Products {get;set;}
    }
}
