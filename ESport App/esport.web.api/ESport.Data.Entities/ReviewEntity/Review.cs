using System;

namespace ESport.Data.Entities
{
    public class Review
    {
        public DateTime ReviewDate { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public virtual Product Product { get; set; }
        public Guid ProductId { get; set; }
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public Review() {
            Id = Guid.NewGuid();
        }

        public Review(User user, Product product, string description, int points):this()
        {
            
            ReviewDate = DateTime.Now;
            User = user;
            Product = product;
            Description = description;
            Points = points;
            ProductId = product.Id;
            UserId = user.Id;
        }

        public override bool Equals(object obj)
        {
            return Id.Equals(((Review)obj).Id);
        }

    }
}
