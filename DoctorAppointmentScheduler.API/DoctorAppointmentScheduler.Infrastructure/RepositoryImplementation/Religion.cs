using DoctorAppointmentScheduler.Application.DTOclass;
using DoctorAppointmentScheduler.Domain.Models;
using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DoctorAppointmentScheduler.Infrastructure.RepositoryImplementation
{
    public class Religionrepository : IReligion
    {
        private readonly DoctorappointmentContext _context;

        public Religionrepository(DoctorappointmentContext context)
        {
            _context = context;
        }

        public string addReligion(string religionName)
        {
            // Check duplicate (ignoring case & soft-delete)
            var exists = _context.Religions
        .Any(r => (r.Isdeleted == false || r.Isdeleted == null) &&
                  EF.Functions.ILike(r.Religionname, religionName));

            if (exists)
                return "Religion already exists.";

            var religion = new Religion
            {
                Religionid = Guid.NewGuid(),
                Religionname = religionName,
                Isdeleted = false
            };

            _context.Religions.Add(religion);
            _context.SaveChanges();

            return "Religion added successfully.";
        }

        public string deleteReligion(Guid religionId)  
        {
            var religion = _context.Religions.FirstOrDefault(r => r.Religionid == religionId);

            if (religion == null)
                return "Religion not found.";

            religion.Isdeleted = true; 
            _context.SaveChanges();

            return "Religion deleted successfully.";
        }

        public List<Religionresponsedto> getallReligion()
        {
            return _context.Religions
                .Where(c => c.Isdeleted == false)
                .Select(c => new Religionresponsedto
                {
                    Religionid = c.Religionid,
                    Religionname = c.Religionname,
                    isdeleted = c.Isdeleted
                })
                .ToList();
        }

        public string updateReligion(Guid Religionid, string Religionname)
        {
            var Religion = _context.Religions.FirstOrDefault(c => c.Religionid == Religionid);
            if (Religion == null)
                return "Religion not found";

            Religion.Religionname = Religionname;
            _context.SaveChanges();
            return "Religion updated successfully";
        }

    }
}
