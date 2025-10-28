using DoctorAppointmentScheduler.Application.DTOclass;
using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;
using DoctorAppointmentScheduler.Domain.Models; 
using System;
using System.Collections.Generic;
using System.Linq;

namespace DoctorAppointmentScheduler.Infrastructure.RepositoryImplementation
{
    public class Occupationrepository : IOccupation
    {
        private readonly DoctorappointmentContext _context;

        public Occupationrepository(DoctorappointmentContext context)
        {
            _context = context;
        }

        public string addOccupation(string occupationName)
        {
            if (string.IsNullOrWhiteSpace(occupationName))
                return "Occupation name cannot be empty";

            var exists = _context.Occupations
                .Any(o => o.Occupationname.ToLower() == occupationName.ToLower() && !o.Isdeleted==false);

            if (exists)
                return "Occupation already exists";

            var entity = new Occupation
            {
                Occupationid = Guid.NewGuid(),
                Occupationname = occupationName,
                Isdeleted = false
            };

            _context.Occupations.Add(entity);
            _context.SaveChanges();
            return "Occupation added successfully";
        }

       

        public string deleteOccupation(Guid occupationId)
        {
            var entity = _context.Occupations.FirstOrDefault(o => o.Occupationid == occupationId);
            if (entity == null) return "Occupation not found";

            entity.Isdeleted = true;
            _context.SaveChanges();
            return "Occupation deleted successfully";
        }

        public List<Occupationresponsedto> getallOccupation()
        {
            return _context.Occupations
               .Select(o => new Occupationresponsedto
               {
                   Occupationid = o.Occupationid,
                   Occupationname = o.Occupationname,
                   isdeleted = o.Isdeleted
               })
               .ToList();
        }

        public string updateOccupation(Guid occupationId, string occupationName)
        {
            var entity = _context.Occupations.FirstOrDefault(o => o.Occupationid == occupationId);
            if (entity == null) return "Occupation not found";

            entity.Occupationname = occupationName;
            _context.SaveChanges();
            return "Occupation updated successfully";
        }
    }
}
