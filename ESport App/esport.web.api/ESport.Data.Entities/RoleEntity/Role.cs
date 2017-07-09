using ESport.Data.Entities;
using System;
using System.Collections.Generic;

namespace ESport.Data.Entities
{
    public class Role
    {
        public Guid Id { get; set; }
        public string RoleId { get; set; }
        public string Description { get; set; }
        public bool Eliminated { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public Role() {
            Id = Guid.NewGuid();
        }
        public Role(string roleId, string description):this()
        {
            RoleId = roleId;
            Description = description;
            Users = new HashSet<User>();
        }
       

        public override bool Equals(object obj)
        {
            return RoleId.Equals(((Role)obj).RoleId);
        }
    }
}
