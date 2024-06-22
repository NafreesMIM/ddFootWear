using DDFootware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly AppDbContext _context;

    public OrdersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetOrders()
    {
        var orders = _context.Orders.Include(o => o.Product).ToList();
        return Ok(orders);
    }

    [HttpGet("{orderId}")]
    public IActionResult GetOrderById(int orderId)
    {
        var order = _context.Orders.Include(o => o.Product).FirstOrDefault(o => o.OrderID == orderId);

        if (order == null)
            return NotFound();

        return Ok(order);
    }

    [HttpPost]
    public IActionResult PlaceOrder(Order order)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // Assuming you have a validation logic for available stock before placing an order
        var productStock = _context.OutletStocks.FirstOrDefault(s => s.ProductID == order.ProductID);
        if (productStock == null || productStock.StockLevel < order.Quantity)
            return BadRequest("Insufficient stock for the selected product.");

        // Process the order
        order.OrderDate = DateTime.Now;
        order.OrderStatus = "Placed";

        _context.Orders.Add(order);
        _context.SaveChanges();

        // Update stock level
        productStock.StockLevel -= order.Quantity;
        _context.SaveChanges();

        return Ok(order);
    }

    // Add other actions as needed...

    [HttpDelete("{orderId}")]
    public IActionResult DeleteOrder(int orderId)
    {
        var order = _context.Orders.Find(orderId);

        if (order == null)
            return NotFound();

        _context.Orders.Remove(order);
        _context.SaveChanges();

        return NoContent();
    }
}
