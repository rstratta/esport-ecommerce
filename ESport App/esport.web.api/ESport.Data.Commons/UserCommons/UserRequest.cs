using System;

namespace ESport.Data.Commons
{
    public class UserRequest
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public string Address { get; set; }
        public bool Eliminated { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public string UserLastName { get; set; }
        public string UserName { get; set; }
        public string NewPassword { get; set; }
        public string Phone { get; set; }

       
    }
}
