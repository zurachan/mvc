using mvc.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc.Domain
{
    public class UserRole : AuditEntity<int>
    {
        [ForeignKey("user")]
        [Column("userId")]
        public int UserId { get; set; }

        [ForeignKey("role")]
        [Column("roleId")]
        public int RoleId { get; set; }

        public virtual User? User { get; set; }
        public virtual Role? Role { get; set; }
    }
}
