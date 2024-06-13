using mvc.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc.Domain
{
    public class Menu : AuditEntity<int>
    {
        [Required]
        [Column("name")]
        public required string Name { get; set; }

        [Required]
        [Column("path")]
        public required string Path { get; set; }
        public virtual List<RoleMenu>? RoleMenus { get; set; }

        [Column("parentId")]
        public int? ParentId { get; set; }
        public virtual Menu? Parent { get; set; }

        public virtual List<Menu>? Children { get; set; }
    }
}
