using System;
using System.Collections.Generic;

namespace ESport.Data.Commons
{

    public class CartDTO
    {
        public Guid CartId {get;set;}
        public double Total { get; set;}
        public List<CartItemDTO> itemsDTO { get; set; }
        public string Opendate { get; set; }
    }
}
