using mvc.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc.Domain
{
    public class Role : AuditEntity<int>
    {
        [Required]
        [Column("name")]
        public required string Name { get; set; }

        public virtual List<UserRole>? UserRoles { get; set; }
        public virtual List<RoleMenu>? RoleControllers { get; set; }
    }
}
