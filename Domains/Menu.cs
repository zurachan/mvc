using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc.Domains
{
    [Table("menu")]
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
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
