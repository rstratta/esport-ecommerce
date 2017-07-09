using System;

namespace ESport.Data.Entities
{
    public class ProductFields
    {
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public Guid FieldId { get; set; }
        public virtual Field Field { get; set; }
        public string Value { get; set; }

        public ProductFields() { }
        public ProductFields(Product product, Field field, string value)
        {
            Product = product;
            Field = field;
            ProductId = product.Id;
            FieldId = field.Id;
            Value = value;
        }

        public override bool Equals(object obj)
        {
            return ProductId.Equals(((ProductFields)obj).ProductId)&& FieldId.Equals(((ProductFields)obj).FieldId);
        }
    }
}
