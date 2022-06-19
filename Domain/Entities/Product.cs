using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Product
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string? Name { get; set; }
    [MaxLength(100)]
    public string? Description { get; set; }
    [MaxLength(50)]
    public string? Sku { get; set; }
    public int ProductCategoryId { get; set; }
    public ProductCategory? ProductCategory { get; set; }
    public int ProductInventoryId { get; set; }
    public ProductInventory? ProductInventory { get; set; }
    public decimal Price { get; set; }
    public int DiscountId { get; set; }
    public Discount? Discount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public DateTime DeletedAt { get; set; }
}