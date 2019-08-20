using System.Threading.Tasks;
using CarpoolSharing.API.Data;
using CarpoolSharing.API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CarpoolSharing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesRepository _repo;
        public EmployeesController(IEmployeesRepository repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _repo.GetEmployees();

            return Ok(employees);
        }
        
        [HttpPost]
        [Route("getAvailableEmployees")]
        public async Task<IActionResult> GetAvailableEmployees(RideForSearchDto rideForSerachDto)
        {
            var employees = await _repo.GetAvailableEmployees(rideForSerachDto);
            return Ok(employees);
        }
    }
}