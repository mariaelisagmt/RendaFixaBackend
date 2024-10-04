using System.ComponentModel.DataAnnotations;

namespace RendaFixa.Domain.Entities;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; protected set; }
}
