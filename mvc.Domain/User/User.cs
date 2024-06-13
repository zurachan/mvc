using mvc.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc.Domain
{
    public class User : AuditEntity<int>
    {
        [Required]
        [Column("full_name")]
        public required string FullName { get; set; }
        [Column("address")]
        public string? Address { get; set; }

        public virtual Account? Account { get; set; }
        public virtual List<UserRole>? UserRoles { get; set; }
    }
}
