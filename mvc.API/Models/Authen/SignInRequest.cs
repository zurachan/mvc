namespace mvc.Models.Authen
{
    public class SignInRequest
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }

    public class SignUpRequest
    {
        public required string Fullname { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
