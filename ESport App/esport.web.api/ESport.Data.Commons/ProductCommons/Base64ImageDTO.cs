using System;

namespace ESport.Data.Commons
{
    public class ProductImageDTO
    {
        public Guid Id {get;set;}
        public string Content { get; set; }

        public ProductImageDTO(Guid id, string content)
        {
            Id = id;
            Content = content;
        }
    }
}
