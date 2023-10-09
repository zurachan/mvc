using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc.Domains
{
    [Table("account")]
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("username")]
        public string Username { get; set; }
        [Required]
        [Column("passwordhash")]
        public string PasswordHash { get; set; }
        [Required]
        [Column("passwordsalt")]
        public string PasswordSalt { get; set; }

        [ForeignKey("user")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
