using System;

namespace ESport.Data.Entities
{
    public class UserContext
    {
        public Guid Token { get; set; }
        public string UserId { get; set; }
        public string SerializedContext { get; set; }

        public UserContext() { }
    }
}
