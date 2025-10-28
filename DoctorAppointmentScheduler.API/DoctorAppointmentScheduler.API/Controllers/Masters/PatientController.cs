using DoctorAppointmentScheduler.Application.DTOclass;
using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentScheduler.API.Controllers.Masters
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PatientDto>> GetAll()
        {
            return Ok(_patientRepository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<PatientDto> GetById(Guid id)
        {
            var patient = _patientRepository.GetById(id);
            if (patient == null) return NotFound("Patient not found");
            return Ok(patient);
        }

        [HttpPost]
        public ActionResult<PatientDto> Add([FromBody] PatientDto dto)
        {
            if (dto == null) return BadRequest("Invalid patient data");
            var created = _patientRepository.Add(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Patientid }, created);
        }

        [HttpPut("{id}")]
        public ActionResult<PatientDto> Update(Guid id, [FromBody] PatientDto dto)
        {
            if (dto == null || id != dto.Patientid) return BadRequest("Patient ID mismatch");
            var updated = _patientRepository.Update(dto);
            if (updated == null) return NotFound("Patient not found");
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var deleted = _patientRepository.Delete(id);
            if (!deleted) return NotFound("Patient not found");
            return Ok("Patient deleted successfully");
        }
    }
}
