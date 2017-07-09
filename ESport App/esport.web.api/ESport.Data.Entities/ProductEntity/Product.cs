using ESport.Data.Commons;
using System;
using System.Collections.Generic;

namespace ESport.Data.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Factory { get; set; }
        public double ReviewAverage { get; set; }
        public bool Eliminated { get; set; }
        public virtual ICollection<ProductImage> Images { get; set; }
        public virtual ICollection<ProductFields> Fields { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public bool BlackProduct { get; set; }
        public int AvailableStock { get; set; }

        public Product()
        {
            Id = Guid.NewGuid();
            Images = new List<ProductImage>();
            ReviewAverage = 0;
            Fields = new HashSet<ProductFields>();
            Reviews = new HashSet<Review>();
            
        }

        public Product(string productId, string name,string description, double price, string factory) : this()
        {
            ProductId = productId;
            ProductName = name;
            Description = description;
            Price = price;
            Factory = factory;
        }

        public bool HasImages()
        {
            return Images.Count != ESportUtils.EMPTY_LIST;
        }

        public override bool Equals(object obj)
        {
            return ProductId.Equals(((Product)obj).ProductId);
        }
    }
}
