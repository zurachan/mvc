using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc.Domains
{
    [Table("role")]
    public class AppRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("role_name")]
        public string RoleName { get; set; }

        public virtual List<UserRole> UserRoles { get; set; }
        public virtual List<RoleController> RoleControllers { get; set; }
    }
}
