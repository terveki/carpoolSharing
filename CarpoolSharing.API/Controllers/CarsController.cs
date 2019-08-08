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
        
        private readonly ICarsRepository _repo;
        public CarsController(ICarsRepository repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            var cars = await _repo.GetCars();

            return Ok(cars);
        }
    }
}