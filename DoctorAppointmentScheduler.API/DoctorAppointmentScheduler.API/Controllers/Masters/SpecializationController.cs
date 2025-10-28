using DoctorAppointmentScheduler.Application.DTOclass;
using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DoctorAppointmentScheduler.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : ControllerBase
    {
        private readonly ISpecialization _specializationRepository;

        public SpecializationController(ISpecialization specializationRepository)
        {
            _specializationRepository = specializationRepository;
        }

        [HttpGet]
        public ActionResult<List<Specializationresponsedto>> GetAll()
        {
            var specializations = _specializationRepository.GetAllSpecializations();
            return Ok(specializations);
        }

        // ✅ Add specialization
        [HttpPost]
        public ActionResult<string> Add([FromBody] string specializationName)
        {
            var result = _specializationRepository.AddSpecialization(specializationName);
            return Ok(result);
        }

        // ✅ Update specialization
        [HttpPut("{id:guid}")]
        public ActionResult<string> Update(Guid id, [FromBody] string specializationName)
        {
            var result = _specializationRepository.UpdateSpecialization(id, specializationName);
            return Ok(result);
        }

        // ✅ Delete specialization
        [HttpDelete("{id:guid}")]
        public ActionResult<string> Delete(Guid id)
        {
            var result = _specializationRepository.DeleteSpecialization(id);
            return Ok(result);
        }
    }
}
