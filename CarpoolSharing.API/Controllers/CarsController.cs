using System.Threading.Tasks;
using CarpoolSharing.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarpoolSharing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        
        private readonly DataContext _context;
        public CarsController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var cars = await _context.Cars.ToListAsync();

            return Ok(cars);
        }
    }
}