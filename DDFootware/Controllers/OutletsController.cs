using DDFootware.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class OutletsController : ControllerBase
{
    private readonly AppDbContext _context;

    public OutletsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Outlets
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Outlet>>> GetOutlets()
    {
        var outlets = await _context.Outlets.ToListAsync();
        return Ok(outlets);
    }

    // GET: api/Outlets/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Outlet>> GetOutlet(int id)
    {
        var outlet = await _context.Outlets.FindAsync(id);

        if (outlet == null)
        {
            return NotFound();
        }

        return Ok(outlet);
    }

    // POST: api/Outlets
    [HttpPost]
    public async Task<ActionResult<Outlet>> AddOutlet(Outlet outlet)
    {
        if (ModelState.IsValid)
        {
            _context.Outlets.Add(outlet);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOutlet), new { id = outlet.OutletID }, outlet);
        }

        return BadRequest(ModelState);
    }

    // PUT: api/Outlets/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOutlet(int id, Outlet outlet)
    {
        if (id != outlet.OutletID)
        {
            return BadRequest();
        }

        _context.Entry(outlet).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!OutletExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/Outlets/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOutlet(int id)
    {
        var outlet = await _context.Outlets.FindAsync(id);

        if (outlet == null)
        {
            return NotFound();
        }

        _context.Outlets.Remove(outlet);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool OutletExists(int id)
    {
        return _context.Outlets.Any(e => e.OutletID == id);
    }
}
