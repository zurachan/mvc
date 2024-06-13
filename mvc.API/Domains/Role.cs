using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc.Domains
{
    [Table("role")]
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        public required string Name { get; set; }

        public virtual List<UserRole>? UserRoles { get; set; }
        public virtual List<RoleMenu>? RoleControllers { get; set; }
    }
}
