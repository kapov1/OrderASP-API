using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("orders")]
public class OrdersController(OrderService orderService) : ControllerBase
{
    [HttpGet("{id:int}")]
    public Results<Ok<OrderResponse>, NotFound> GetById(int id)
    {
        var order = orderService.Find(id);

        if (order is null) return TypedResults.NotFound();

        return TypedResults.Ok(new OrderResponse(order));
    }

    [HttpPost]
    public ActionResult<OrderResponse> Create([FromBody] OrderCreateRequest request)
    {
        var result = (Result<Order>)orderService.Add(request);

        if (result.IsFailure) return BadRequest("Order with this id doesn't exist");

        var order = result.Value ?? throw new ArgumentNullException();

        var response = new OrderResponse(order);

        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpDelete("{id:int}")]
    public Results<Ok, NotFound<string>> Delete(int id)
    {
        var result = (Result)orderService.Remove(id);

        if (result.IsFailure) return TypedResults.NotFound("Order with this id doesn't exist");

        return TypedResults.Ok();
    }
}