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
        public required string Username { get; set; }
        [Required]
        [Column("passwordhash")]
        public required string PasswordHash { get; set; }
        [Required]
        [Column("passwordsalt")]
        public required string PasswordSalt { get; set; }

        [ForeignKey("user")]
        [Column("userId")]
        public int UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
