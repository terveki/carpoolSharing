using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CarpoolSharing.API.Data;
using CarpoolSharing.API.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarpoolSharing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RidesController : ControllerBase
    {
        private readonly IRidesRepository _repo;
        private readonly IMapper _mapper;

        public RidesController(IRidesRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRides()
        {
            var rides = await _repo.GetRides();

            var ridesToReturn = _mapper.Map<IEnumerable<RideForListDto>>(rides);

            return Ok(ridesToReturn);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRide(int id)
        {
            var ride = await _repo.GetRide(id);

            var rideToReturn = _mapper.Map<RideForDetailedDto>(ride);

            return Ok(rideToReturn);

        }
        
    }
}