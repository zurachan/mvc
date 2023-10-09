using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc.Domains
{
    [Table("user_role")]
    public class UserRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("user")]
        [Column("userId")]
        public int UserId { get; set; }

        [ForeignKey("role")]
        [Column("roleId")]
        public int RoleId { get; set; }

        public virtual User User { get; set; }
        public virtual AppRole Role { get; set; }
    }
}
