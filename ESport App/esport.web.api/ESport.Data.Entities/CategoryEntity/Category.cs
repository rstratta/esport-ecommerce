using ESport.Data.Commons;
using ESport.Data.Entities;
using System;
using System.Collections.Generic;

namespace ESport.Data.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string CategoryId { get; set; }
        public string Description { get; set; }
        public bool Eliminated { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            Id = Guid.NewGuid();
            Products = new HashSet<Product>();
        }

        public Category(string categoryId, string description) : this()
        {
            CategoryId = categoryId;
            Description = description;
        }

        public override bool Equals(object obj) 
        {
            return CategoryId.Equals(((Category)obj).CategoryId);
        } 
        public bool HasProducts()
        {
            return Products.Count != ESportUtils.EMPTY_LIST;
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
    }
}
