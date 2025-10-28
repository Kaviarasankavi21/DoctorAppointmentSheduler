using DoctorAppointmentScheduler.Application.DTOclass;
using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DoctorAppointmentScheduler.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OccupationController : ControllerBase
    {
        private readonly IOccupation _occupationRepository;

        public OccupationController(IOccupation occupationRepository)
        {
            _occupationRepository = occupationRepository;
        }

        [HttpGet]
        public ActionResult<List<Occupationresponsedto>> GetAllOccupations()
        {
            var result = _occupationRepository.getallOccupation();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<string> Add([FromBody] string occupationName)
        {
            var result = _occupationRepository.addOccupation(occupationName);
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public ActionResult<string> Update(Guid id, [FromBody] string occupationName)
        {
            var result = _occupationRepository.updateOccupation(id, occupationName);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public ActionResult<string> Delete(Guid id)
        {
            var result = _occupationRepository.deleteOccupation(id);
            return Ok(result);
        }
    }
}
