using DoctorAppointmentScheduler.Application.DTOclass;
using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentScheduler.API.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaritalstatusController : ControllerBase
    {
        private readonly IMaritalstatus _maritalstatusRepository;

        public MaritalstatusController(IMaritalstatus maritalstatusRepository)
        {
            _maritalstatusRepository = maritalstatusRepository;
        }

        [HttpGet]
        public ActionResult<List<Maritalstatusresponsedto>> GetAll()
        {
            var result = _maritalstatusRepository.getallMaritalstatus();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult <string> Add([FromBody] string maritalStatusName)
        {
            var result = _maritalstatusRepository.addMaritalstatus(maritalStatusName);
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public ActionResult<string> Update(Guid id, [FromBody] string maritalStatusName)
        {
            var result = _maritalstatusRepository.updateMaritalstatus(id, maritalStatusName);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public ActionResult<string> Delete(Guid id)
        {
            var result = _maritalstatusRepository.deleteMaritalstatus(id);
            return Ok(result);
        }
    }
}

