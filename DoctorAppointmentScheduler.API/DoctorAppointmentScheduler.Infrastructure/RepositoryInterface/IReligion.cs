using DoctorAppointmentScheduler.Application.DTOclass;
using System;
using System.Collections.Generic;

namespace DoctorAppointmentScheduler.Infrastructure.RepositoryInterface
{
    public interface IReligion
    {
        string addReligion(string religionName);
        List<Religionresponsedto> getallReligion();
        string deleteReligion(Guid religionId);   // ✅ fixed here
        string updateReligion(Guid religionId, string religionName);
    }
}
