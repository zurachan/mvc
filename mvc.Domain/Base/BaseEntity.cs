using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc.Domain.Base
{
    public interface IBaseEntity<T>
    {
        T Id { get; set; }
    }

    public interface IDeleteEntity
    {
        bool IsDeleted { get; set; }
    }

    public interface IDeleteEntity<T> : IBaseEntity<T>, IDeleteEntity
    {
    }

    public interface IAuditEntity
    {
        DateTime CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
        string UpdatedBy { get; set; }
    }
    public interface IAuditEntity<T> : IAuditEntity, IDeleteEntity<T>
    {
    }

    public abstract class BaseEntity<T> : IBaseEntity<T>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public virtual required T Id { get; set; }
    }

    public abstract class DeleteEntity<T> : BaseEntity<T>, IDeleteEntity<T>
    {
        public bool IsDeleted { get; set; }
    }

    public abstract class AuditEntity<T> : DeleteEntity<T>, IAuditEntity<T>
    {
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
