using System.Threading.Tasks;
using CarpoolSharing.API.Data;
using CarpoolSharing.API.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarpoolSharing.API.Controllers
{
    [Route("api/[controller]/[action]")]
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

        [HttpPost]
        [ActionName("getAvailableCars")]
        public async Task<IActionResult> GetAvailableCars(RideForSearchDto rideForSerachDto)
        {
            var cars = await _repo.GetAvailableCars(rideForSerachDto);
            return Ok(cars);
        }

        [HttpGet("{id}")]
        [ActionName("GetCarStatistics")]
        public async Task<IActionResult> GetCarStatistics(int id)
        {
            var ridesPerYear = await _repo.GetCarStatistics(id);

            return Ok(ridesPerYear);

        }
    }
}