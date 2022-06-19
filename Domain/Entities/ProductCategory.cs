using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class ProductCategory
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string? Name { get; set; }
    [MaxLength(100)]
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public DateTime DeletedAt { get; set; }
    public List<Product>? Products { get; set; }
}