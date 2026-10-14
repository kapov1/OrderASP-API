public class OrderStorage
{
    private readonly List<Order> _orders = new List<Order>();

    public IReadOnlyList<Order> Orders => _orders;

    public void Add(Order order) => _orders.Add(order);
    public void Remove(int id)
    {
        Order order = _orders.First(order => order.Id == id);

        _orders.Remove(order);
    }
}