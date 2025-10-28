using DoctorAppointmentScheduler.Application.DTOclass;
using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DoctorAppointmentScheduler.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TitleController : ControllerBase
    {
        private readonly ITitle _titleRepository;

        public TitleController(ITitle titleRepository)
        {
            _titleRepository = titleRepository;
        }

        [HttpGet]
        public ActionResult<List<Titleresponsedto>> GetAllTitles()
        {
            var titles = _titleRepository.getallTitle();

            if (titles == null || titles.Count == 0)
                return NotFound("No titles found.");

            return Ok(titles);
        }

        [HttpPost]
        public ActionResult<string> AddTitle([FromBody] Titledto request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Titlename))
                return BadRequest("Title name is required.");

            var result = _titleRepository.addTitle(request.Titlename.Trim());

            if (result == "Title already exists.")
                return Conflict(result); 

            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public ActionResult<string> UpdateTitle(Guid id, [FromBody] Titledto request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Titlename))
                return BadRequest("Title name is required.");

            var result = _titleRepository.updateTttitle(id, request.Titlename.Trim());

            if (result == "Title not found.")
                return NotFound(result);

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public ActionResult<string> DeleteTitle(Guid id)
        {
            var result = _titleRepository.deleteTitle(id);

            if (result == "Title not found.")
                return NotFound(result);

            return Ok(result);
        }
    }
}
