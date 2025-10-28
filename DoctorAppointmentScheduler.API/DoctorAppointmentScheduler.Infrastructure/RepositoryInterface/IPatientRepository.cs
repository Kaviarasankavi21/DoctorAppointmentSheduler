using DoctorAppointmentScheduler.Application.DTOclass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduler.Infrastructure.RepositoryInterface
{
    public interface IPatientRepository
    {
        IEnumerable<PatientDto> GetAll();
        PatientDto GetById(Guid patientId);
        PatientDto Add(PatientDto patientDto);
        PatientDto Update(PatientDto patientDto);
        bool Delete(Guid patientId);
    }
}
