using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc.Domains
{
    [Table("role_controller")]
    public class RoleController
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("role")]
        [Column("roleId")]
        public int RoleId { get; set; }

        [ForeignKey("controller")]
        [Column("controllerId")]
        public int ControllerId { get; set; }

        public virtual AppRole Role { get; set; }
        public virtual AppController Controller { get; set; }
    }
}
