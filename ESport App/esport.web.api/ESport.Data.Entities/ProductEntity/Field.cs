using System;
using System.Collections.Generic;

namespace ESport.Data.Entities
{
    public class Field
    {
        public Guid Id { get; set; }
        public virtual ICollection<ProductFields> Products { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        

        public Field()
        {
            Id = Guid.NewGuid();
            Products = new HashSet<ProductFields>();
        }
        public Field(string fName, string fType):base()
        {
            Name = fName;
            Type = fType;
        }

        public override bool Equals(object obj)
        {
            return Id.Equals(((Field)obj).Id);
        }

    }
}
