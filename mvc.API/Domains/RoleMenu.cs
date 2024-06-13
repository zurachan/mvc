using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc.Domains
{
    [Table("role_menu")]
    public class RoleMenu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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
