using ESport.Data.Commons;
using System;
using System.Collections.Generic;

namespace ESport.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string EMail { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool Eliminated { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public int Points { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
            Roles = new HashSet<Role>();
            Reviews = new HashSet<Review>();
            Carts = new HashSet<Cart>();
        }

        public User(string userId, string userName, string userLastName, string password,
            string address, string mail, string phone) : this()
        {
            UserId = userId;
            UserName = userName;
            UserLastName = userLastName;
            Password = password;
            Address = address;
            EMail = mail;
            Phone = phone;
        }

       

        public bool HasRole()
        {
            return Roles.Count != ESportUtils.EMPTY_LIST;
        }

        public override bool Equals(object obj)
        {
            return UserId.Equals(((User)obj).UserId);
        }
    }
}
