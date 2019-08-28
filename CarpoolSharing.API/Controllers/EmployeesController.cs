using System.Threading.Tasks;
using CarpoolSharing.API.Data;
using CarpoolSharing.API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CarpoolSharing.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesRepository _repo;
        private readonly IEmployeeRideRepository _emplRideRepo;

        public EmployeesController(IEmployeesRepository repo, IEmployeeRideRepository emplRideRepo)
        {
            _repo = repo;
            _emplRideRepo = emplRideRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _repo.GetEmployees();

            return Ok(employees);
        }
        
        [HttpPost]
        [ActionName("GetAvailableEmployees")]
        public async Task<IActionResult> GetAvailableEmployees(RideForSearchDto rideForSerachDto)
        {
            var employees = await _repo.GetAvailableEmployees(rideForSerachDto);
            return Ok(employees);
        }

        [HttpGet("{month}")]
        [ActionName("GetEmplStatsByMonth")]
        public async Task<IActionResult> GetEmplStatsByMonth(int month)
        {
            var emplPerMonth = await _emplRideRepo.GetEmployeeStatsByMonth(month);

            return Ok(emplPerMonth);

        }
    }
}