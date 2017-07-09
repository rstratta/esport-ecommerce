using System;


namespace ESport.Data.Entities
{
    
    public class ProductImage
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public string Base64EncodedImage { get; set; }

        public ProductImage() { }
        public ProductImage(Guid id, string content):this()
        {
            if (id.Equals(Guid.Empty))
            {
                Id = Guid.NewGuid();
            }else { 
                Id = id;
            }
            Base64EncodedImage = content;
        }

        public ProductImage(string content) : this(Guid.NewGuid(), content) { }
    }
}
