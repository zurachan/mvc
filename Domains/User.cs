using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc.Domains
{
    [Table("user")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("full_name")]
        public string FullName { get; set; }
        [Required]
        [Column("address")]
        public string Address { get; set; }

        public virtual Account Account { get; set; }
        public virtual List<UserRole> UserRoles { get; set; }
    }
}
