using mvc.Domain;

namespace mvc.API.Models.Authen
{
    public class AuthenResponse
    {
        public User? User { get; set; }
        public string? Token { get; set; }
        public string? Message { get; set; }
        public List<Menu>? Menu { get; set; }
    }
}
