using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CarpoolSharing.API.Data;
using CarpoolSharing.API.Dtos;
using CarpoolSharing.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarpoolSharing.API.Controllers
{
    [Route("api/[controller]/[action]")]
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

        [HttpGet("{id}", Name = "GetRide")]
        [ActionName("GetRide")]
        public async Task<IActionResult> GetRide(int id)
        {
            var ride = await _repo.GetRide(id);

            var rideToReturn = _mapper.Map<RideForDetailedDto>(ride);

            return Ok(rideToReturn);

        }

        [HttpPost()]
        [ActionName("AddNewRide")]
        public async Task<IActionResult> AddNewRide(Ride ride)
        {
            var rideCreated = await _repo.Add(ride);
            var rideToReturn = _mapper.Map<RideForDetailedDto>(rideCreated);

            return CreatedAtRoute("GetRide", new { controller = "Rides", id = rideCreated.RideId }, rideToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRide(int id)
        {
            var rideFromRepo = await _repo.GetRide(id);
            _repo.Delete(rideFromRepo);

            if (await _repo.SaveAll())
                return Ok();

            return BadRequest("Failed to delete the ride");
        }

    }
}