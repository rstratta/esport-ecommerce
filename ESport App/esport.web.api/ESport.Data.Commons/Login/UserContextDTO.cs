using System.Collections.Generic;

namespace ESport.Data.Commons
{

    public class UserContextDTO
    {
        public CartDTO PendingCart { get; set; }
        public List<PendingReviewDTO> PendingsReviewDTO { get; set; }
        public string Token { get; set; }
        public UserDTO UserDTO { get; set; }
        
    }
}
