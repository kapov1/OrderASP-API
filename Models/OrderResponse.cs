public class OrderResponse(Order order)
{
    public uint Id { get; set; } = order.Id;
    public string CustomerName { get; set; } = order.CustomerName;
    public string ProductName { get; } = order.ProductName;
    public string Description { get; } = order.Description; 
    public DateTime CreatedAt { get; } = order.CreatedAt;
}