using DoctorAppointmentScheduler.Application.DTOclass;
using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DoctorAppointmentScheduler.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountry _countryRepository;

        public CountryController(ICountry countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public ActionResult<List<countryresponsedto>> GetAll()
        {
            var countries = _countryRepository.getallcountry();
            return Ok(countries);
        }

        [HttpPost]
        public ActionResult<string> Add(string countryName)
        {
            var result = _countryRepository.addcountry(countryName);
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public ActionResult<string> Update(Guid id, [FromBody] string countryName)
        {
            var result = _countryRepository.updatecountry(id, countryName);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles ="Admin")]
        public ActionResult<string> Delete(Guid id)
        {
            var result = _countryRepository.deletecountry(id);
            return Ok(result);
        }
    }
}
