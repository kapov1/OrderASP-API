public class OrderService(OrderStorage orderStorage)
{
    private static uint idCounter = 1; // идея с ID нелючшая но это просто чтобы не парится

    public Result<Order> Add(OrderCreateRequest request)
    {
        Order order = new(idCounter++, request.ProductName, request.CustomerName, request.Description);

        orderStorage.Add(order);

        return Result<Order>.Success(order);
    }

    public Result Remove(int id)
    {
        if (!orderStorage.Orders.Any(order => order.Id == id)) return Result.Failure("This order is not in the storage.");

        orderStorage.Remove(id);

        return Result.Success();
    }

    public Order? Find(int id)
    {
        var order = orderStorage.Orders.FirstOrDefault(order => order.Id == id);

        return order;
    }
}