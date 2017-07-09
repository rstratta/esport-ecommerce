using System;

namespace ESport.Data.Entities
{
    public class PointSystemConfiguration
    {
        public Guid Id { get; set; }
        public string PropertyName { get; set; }
        public double PropertyValue { get; set; }

        public PointSystemConfiguration()
        {
            Id = Guid.NewGuid();
        }
    }
}
