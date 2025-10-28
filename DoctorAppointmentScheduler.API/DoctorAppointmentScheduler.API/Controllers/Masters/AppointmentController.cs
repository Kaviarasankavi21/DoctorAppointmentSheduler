using DoctorAppointmentScheduler.Application.DTOclass;
using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DoctorAppointmentScheduler.API.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepository _repository;

        public AppointmentController(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Appointment
        [HttpGet]
        public ActionResult<List<AppointmentDto>> GetAppointments()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "Userid");

            var appointments = _repository.GetAll();
            return Ok(appointments);
        }
        // GET: api/Patient
        [HttpGet("patients")]
        public ActionResult<List<PatientsDDL>> GetPatientsDropDown([FromQuery] string username)
        {
            var patients = _repository.GetPatients(username);
            return Ok(patients);
        }

        // GET: api/Appointment/{id}
        [HttpGet("{id}")]
        public ActionResult<AppointmentDto> GetAppointment(Guid id)
        {
            var appointment = _repository.GetById(id);
            if (appointment == null)
                return NotFound("Appointment not found");

            return Ok(appointment);
        }

        // POST: api/Appointment
        [HttpPost]
        public ActionResult<AppointmentDto> CreateAppointment([FromBody] AppointmentDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid appointment data");

            // Ensure new GUID if not provided
            dto.AppointmentId = dto.AppointmentId == Guid.Empty ? Guid.NewGuid() : dto.AppointmentId;
            dto.Createdate = DateTime.UtcNow;

            _repository.Add(dto);

            // Return the created appointment object
            var createdAppointment = _repository.GetById(dto.AppointmentId);
            return Ok(createdAppointment);
        }

        // PUT: api/Appointment/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateAppointment(Guid id, [FromBody] AppointmentDto dto)
        {
            var existing = _repository.GetById(id);
            if (existing == null)
                return NotFound("Appointment not found");

            dto.AppointmentId = id;
            dto.Updatedate = DateTime.UtcNow;

            _repository.Update(dto);
            return Ok("Appointment updated successfully");
        }

        // DELETE: api/Appointment/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteAppointment(Guid id)
        {
            var existing = _repository.GetById(id);
            if (existing == null)
                return NotFound("Appointment not found");

            _repository.Delete(id);
            return Ok("Appointment cancelled successfully");
        }

        // GET: api/Appointment/details/{id}
        [HttpGet("details/{id}")]
        public ActionResult<AppointmentDetailDto> GetAppointmentDetails(Guid id)
        {
            var appointment = _repository.GetAppointmentDetails(id);
            if (appointment == null)
                return NotFound("Appointment not found");

            return Ok(appointment);
        }
    }
}
