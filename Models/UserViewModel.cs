using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Address { get; set; }
        public int AccountId { get; set; }
        [Required]
        public string Username { get; set; }
        public int RoleId { get; set; }
    }
}
