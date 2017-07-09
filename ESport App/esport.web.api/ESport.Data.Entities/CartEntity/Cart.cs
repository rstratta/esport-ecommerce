using ESport.Data.Commons;
using ESport.Data.Entities;
using System;
using System.Collections.Generic;

namespace ESport.Data.Entities
{
    public class Cart
    {
        public static string INIT_CART = "I";
        public static string PENDING_CART = "P";
        public static string CANECELED_CART = "C";
        public static string FINISHED_CART = "F";
        public DateTime Opendate { get; set; }
        public string State { get; set; }
        public double Total { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryPhone { get; set; }
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
        public virtual ICollection<CartItem> Items { get; set; }
        public Guid CartId { get; set; }
        
        public Cart()
        {
            CartId = Guid.NewGuid();
            Items = new HashSet<CartItem>();
            State = INIT_CART;
            Opendate = DateTime.Now;
        }
        
        
        
        public bool HasProducts()
        {
            return Items.Count != ESportUtils.EMPTY_LIST;
        }

        public override bool Equals(object obj)
        {
            return CartId.Equals(((Cart)obj).CartId);
        }
    }
}
