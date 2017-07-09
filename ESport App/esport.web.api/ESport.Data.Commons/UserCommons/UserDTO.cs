using System.Collections.Generic;

namespace ESport.Data.Commons
{

    public class UserDTO
    {
        public string Address { get; set; }
        public bool Eliminated { get; set; }
        public string EMail { get; set; }
        public string UserLastName { get; set;}
        public string UserName { get; set; }
        public List<RoleDTO> Roles { get; set; }
        public string UserId { get; set; }
        public string Phone { get; set; }
        public int Points { get; set; }

        public UserDTO()
        {
            Roles = new List<RoleDTO>();
        }
    }
}
