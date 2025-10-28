using DoctorAppointmentScheduler.Application.DTOclass;
using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;
using DoctorAppointmentScheduler.Domain.Models; 
using System.Collections.Generic;
using System.Linq;

namespace DoctorAppointmentScheduler.Infrastructure.RepositoryImplementation
{
    public class Maritalstatusrepository : IMaritalstatus
    {
        private readonly DoctorappointmentContext _context;

        public Maritalstatusrepository(DoctorappointmentContext context)
        {
            _context = context;
        }

        public string addMaritalstatus(string maritalstatusname)
        {
            if (string.IsNullOrWhiteSpace(maritalstatusname))
                return "Marital status name cannot be empty";

            var exists = _context.Maritalstatuses
                .Any(m => m.Maritalstatus1.ToLower() == maritalstatusname.ToLower() && !m.Isdeleted==false);

            if (exists)
                return "Marital status already exists";

            var entity = new Maritalstatus
            {
                Maritalstatusid = Guid.NewGuid(),
                Maritalstatus1 = maritalstatusname,
                Isdeleted = false
            };

            _context.Maritalstatuses.Add(entity);
            _context.SaveChanges();
            return "Marital status added successfully";
        }

        public List<Maritalstatusresponsedto> getallMaritalstatus()
        {
            return _context.Maritalstatuses
                .Select(m => new Maritalstatusresponsedto
                {
                    Maritalstatusid = m.Maritalstatusid,
                    Maritalstatus1 = m.Maritalstatus1,
                    isdeleted = m.Isdeleted
                })
                .ToList();
        }

        public string deleteMaritalstatus(Guid maritalstatusid)
        {
            var entity = _context.Maritalstatuses.FirstOrDefault(m => m.Maritalstatusid == maritalstatusid);
            if (entity == null) return "Marital status not found";

            entity.Isdeleted = true;
            _context.SaveChanges();
            return "Marital status deleted successfully";
        }

        public string updateMaritalstatus(Guid maritalstatusid, string maritalstatusname)
        {
            var entity = _context.Maritalstatuses.FirstOrDefault(m => m.Maritalstatusid == maritalstatusid);
            if (entity == null) return "Marital status not found";

            entity.Maritalstatus1 = maritalstatusname;
            _context.SaveChanges();
            return "Marital status updated successfully";
        }
    }
}
