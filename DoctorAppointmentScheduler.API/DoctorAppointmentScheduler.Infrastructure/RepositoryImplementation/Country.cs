using DoctorAppointmentScheduler.Application.DTOclass;
using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;
using DoctorAppointmentScheduler.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DoctorAppointmentScheduler.Infrastructure.RepositoryImplementation
{
    public class CountryRepository : ICountry
    {
        private readonly DoctorappointmentContext _context;

        public CountryRepository(DoctorappointmentContext context)
        {
            _context = context;
        }

        public string addcountry(string countryname)
        {
            var exists = _context.Countries
          .Any(c => c.Countryname.ToLower() == countryname.ToLower() && c.Isdeleted == false);

            if (exists)
                return "Country already exists";

            var newCountry = new Country
            {
                Countryid = Guid.NewGuid(),
                Countryname = countryname,
                Isdeleted = false
            };

            _context.Countries.Add(newCountry);
            _context.SaveChanges();
            return "Country added successfully";
        }

        public string deletecountry(Guid countryid)
        {
            var country = _context.Countries.FirstOrDefault(c => c.Countryid == countryid);
            if (country == null)
                return "Country not found";

            country.Isdeleted = true;
            _context.SaveChanges();
            return "Country deleted successfully";
        }

        public List<countryresponsedto> getallcountry()
        {
            return _context.Countries
                .Where(c => c.Isdeleted == false)
                .Select(c => new countryresponsedto
                {
                    countryid = c.Countryid,
                    countryname = c.Countryname,
                    isdeleted = c.Isdeleted
                })
                .ToList();
        }

        public string updatecountry(Guid countryid, string countryname)
        {
            var country = _context.Countries.FirstOrDefault(c => c.Countryid == countryid);
            if (country == null)
                return "Country not found";

            country.Countryname = countryname;
            _context.SaveChanges();
            return "Country updated successfully";
        }
    }
}
