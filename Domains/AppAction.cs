using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc.Domains
{
    [Table("action")]
    public class AppAction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("action_name")]
        public string ActionName { get; set; }
        [Required]
        [Column("action_path")]
        public string ActionPath { get; set; }

        [ForeignKey("controller")]
        public int ControllerId { get; set; }

        public virtual AppController Controller { get; set; }
    }
}
