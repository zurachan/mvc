using mvc.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc.Domain
{
    public class RoleMenu : AuditEntity<int>
    {
        [ForeignKey("role")]
        [Column("roleId")]
        public int RoleId { get; set; }

        [ForeignKey("menu")]
        [Column("menuId")]
        public int MenuId { get; set; }

        public virtual Role? Role { get; set; }
        public virtual Menu? Menu { get; set; }
    }
}
