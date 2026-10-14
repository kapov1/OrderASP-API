public class Order(uint id, string productName, string customerName, string description = "")
{
    public uint Id { get; } = id;
    public string CustomerName { get; } = customerName;
    public string ProductName { get; } = productName;
    public string Description { get; } = description;
    public DateTime CreatedAt { get; } = DateTime.Now;
}