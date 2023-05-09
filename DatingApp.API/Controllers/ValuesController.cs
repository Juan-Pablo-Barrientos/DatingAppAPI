using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    private readonly DataContext _context;
    private readonly ILogger<ValuesController> _logger;
    public ValuesController(DataContext context, ILogger<ValuesController> logger)
    {
            _context = context;
            _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetValues()
    {
        var values = await _context.Values.ToListAsync();
         return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetValue(int id)
    {
        var value = await _context.Values.FirstOrDefaultAsync(x => x.Id==id);
        return Ok(value);
    }
}
