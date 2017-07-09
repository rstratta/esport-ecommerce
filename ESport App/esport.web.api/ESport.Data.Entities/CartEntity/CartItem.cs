using ESport.Data.Entities;
using System;

namespace ESport.Data.Entities
{
    public class CartItem
    {
        public string ItemDescription { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public bool PendingReview { get; set; }
        public virtual Product Product { get; set; }
        public Guid ProductId { get; set; }
        public virtual Cart Cart { get; set; }
        public Guid CartItemId { get; set; }

        
        public CartItem()
        {
            PendingReview = true;
        }

        public CartItem(Product product, int quantity) : this()
        {
            CartItemId = Guid.NewGuid();
            Product = product;
            ProductId = product.Id;
            Quantity = quantity;
            UnitPrice = product.Price;
            Amount = UnitPrice * Quantity;
            ItemDescription = product.Description;
        }

        
        public override bool Equals(object obj)
        {
            return ProductId.Equals(((CartItem)obj).ProductId);
        }
    }
}
