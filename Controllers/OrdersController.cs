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
        var result = orderService.Add(request);

        if (result.IsFailure) return BadRequest(result.ErrorMessage);

        var order = result.Value!;

        var response = new OrderResponse(order);

        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpDelete("{id:int}")]
    public Results<NoContent, NotFound<string>> Delete(int id)
    {
        var result = orderService.Remove(id);

        if (result.IsFailure) return TypedResults.NotFound(result.ErrorMessage);

        return TypedResults.NoContent();
    }
}