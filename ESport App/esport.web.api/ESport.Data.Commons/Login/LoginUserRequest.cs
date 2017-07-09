namespace ESport.Data.Commons
{
    public class LoginUserRequest
    {
        public string UserId { get; set; }
        public string UserPassword { get; set; }

        public override bool Equals(object obj)
        {
            return UserId.Equals(((LoginUserRequest)obj).UserId);
        }
    }
}
