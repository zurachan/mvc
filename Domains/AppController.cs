using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc.Domains
{
    [Table("controller")]
    public class AppController
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("controller_name")]
        public required string ControllerName { get; set; }
        [Required]
        [Column("controller_path")]
        public required string ControllerPath { get; set; }

        public virtual List<RoleController>? RoleControllers { get; set; }
        public virtual List<AppAction>? Actions { get; set; }
    }
}
