using System.ComponentModel.DataAnnotations;

namespace OrderManage.Models;


public class Order
{
    [Required]
    public int Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    [Required]
    public int CustomerId { get; set; } // Foreign key for Customer
}
