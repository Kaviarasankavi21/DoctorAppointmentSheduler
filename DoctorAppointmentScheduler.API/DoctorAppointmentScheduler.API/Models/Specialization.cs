using System;
using System.Collections.Generic;

namespace DoctorAppointmentScheduler.API.Models;

public partial class Specialization
{
    public Guid SpecializationId { get; set; }

    public string SpecializationName { get; set; } = null!;

    public bool? IsDeleted { get; set; }
}
