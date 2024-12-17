using System.ComponentModel.DataAnnotations;

namespace OrderManage.Models;

public class Customer
{
    [Required]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<Order> Orders { get; set; } = new();
}