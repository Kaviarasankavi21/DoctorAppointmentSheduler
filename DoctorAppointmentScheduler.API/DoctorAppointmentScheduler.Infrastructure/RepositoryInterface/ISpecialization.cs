using DoctorAppointmentScheduler.Application.DTOclass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduler.Infrastructure.RepositoryInterface
{
    public interface ISpecialization
    {
        string AddSpecialization(string specializationName);
        List<Specializationresponsedto> GetAllSpecializations();
        string DeleteSpecialization(Guid specializationId);
        string UpdateSpecialization(Guid specializationId, string specializationName);
    }
}
