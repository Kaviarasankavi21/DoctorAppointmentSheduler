using DoctorAppointmentScheduler.Application.DTOclass;
using DoctorAppointmentScheduler.Domain.Models;
using DoctorAppointmentScheduler.Infrastructure.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduler.Infrastructure.RepositoryImplementation
{
    public class Specializationrepository : ISpecialization
    {
        private readonly DoctorappointmentContext _context;
        
        public Specializationrepository(DoctorappointmentContext context)
        {
            _context = context;
        }

        public string AddSpecialization(string specializationName)
        {
            var exists = _context.Specializations
                .Any(s => s.SpecializationName.ToLower() == specializationName.ToLower() && s.IsDeleted == false);

            if (exists)
                return "Specialization already exists.";

            var newSpecialization = new Specialization
            {
                SpecializationId = Guid.NewGuid(),
                SpecializationName = specializationName,
                IsDeleted = false
            };

            _context.Specializations.Add(newSpecialization);
            _context.SaveChanges();
            return "Specialization added successfully.";
        }

        public string DeleteSpecialization(Guid specializationId)
        {
            var specialization = _context.Specializations.FirstOrDefault(s => s.SpecializationId == specializationId);
            if (specialization == null)
                return "Specialization not found.";

            specialization.IsDeleted = true;
            _context.SaveChanges();
            return "Specialization deleted successfully.";
        }

        public List<Specializationresponsedto> GetAllSpecializations()
        {
            return _context.Specializations
                .Where(s => s.IsDeleted == false)
                .Select(s => new Specializationresponsedto
                {
                    SpecializationId = s.SpecializationId,
                    SpecializationName = s.SpecializationName,
                    IsDeleted = s.IsDeleted
                })
                .ToList();
        }

        public string UpdateSpecialization(Guid specializationId, string specializationName)
        {
            var specialization = _context.Specializations.FirstOrDefault(s => s.SpecializationId == specializationId);
            if (specialization == null)
                return "Specialization not found.";

            specialization.SpecializationName = specializationName;
            _context.SaveChanges();
            return "Specialization updated successfully.";
        }
    }
}
