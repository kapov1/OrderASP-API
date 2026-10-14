using System.ComponentModel.DataAnnotations;

public class OrderCreateRequest
{
    [Required]
    [StringLength(30, MinimumLength = 3)]
    [CustomerName]
    public string CustomerName { get; set; } = "";

    [Required]
    [StringLength(30, MinimumLength = 3)]
    [ProductName]
    public string ProductName { get; set; } = "";

    [StringLength(300)]
    public string Description { get; set; } = "";
}