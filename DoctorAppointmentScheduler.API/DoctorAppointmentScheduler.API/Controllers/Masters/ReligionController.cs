using DoctorAppointmentScheduler.Application.DTOclass;
using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DoctorAppointmentScheduler.API.Controllers    
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReligionController : ControllerBase
    {
        private readonly IReligion _religionRepository;

        public ReligionController(IReligion religionRepository)
        {
            _religionRepository = religionRepository;
        }

        [HttpPost]
        public ActionResult<string> AddReligion([FromBody] Religiondto request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Religionname))
                return BadRequest("Religion name is required.");

            var result = _religionRepository.addReligion(request.Religionname);
            return Ok(result);
        }

        [HttpGet]
        public ActionResult<List<Religionresponsedto>> GetAllReligions()
        {
            var religions = _religionRepository.getallReligion();

            if (religions == null || religions.Count == 0)
                return NotFound("No religions found.");

            return Ok(religions);
        }

        [HttpPut("{id:guid}")]
        public ActionResult<string> UpdateReligion(Guid id, [FromBody] Religiondto request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Religionname))
                return BadRequest("Religion name is required.");

            var result = _religionRepository.updateReligion(id, request.Religionname);

            if (result == "Religion not found.")
                return NotFound(result);

            return Ok(result);
        }


        [HttpDelete("{id:guid}")]
        public ActionResult<string> DeleteReligion(Guid id)
        {
            var result = _religionRepository.deleteReligion(id);
            return Ok(result);
        }
    }
}
