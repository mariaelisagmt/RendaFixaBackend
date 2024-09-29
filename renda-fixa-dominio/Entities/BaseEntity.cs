using System.ComponentModel.DataAnnotations;

namespace RendaFixa.Domain.Entities;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}
