using DoctorAppointmentScheduler.Application.DTOclass;
using DoctorAppointmentScheduler.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduler.Infrastructure.RepositoryInterface
{
    public interface IAppointmentRepository
    {
        List<AppointmentDto> GetAll();

        // Get appointment by ID (return DTO)
        AppointmentDto GetById(Guid id);

        // Add new appointment (from DTO)
        void Add(AppointmentDto appointment);

        // Update existing appointment (from DTO)
        void Update(AppointmentDto appointment);

        // Delete appointment by ID
        void Delete(Guid id);
        AppointmentDetailDto GetAppointmentDetails(Guid id);

        List<PatientsDDL> GetPatients(string userName);

    }
}
