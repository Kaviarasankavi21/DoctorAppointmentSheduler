using System;
using System.Collections.Generic;

namespace DoctorAppointmentScheduler.API.Models;

public partial class Appointment
{
    public Guid Appointmentid { get; set; }

    public Guid Patientid { get; set; }

    public Guid Doctorid { get; set; }

    public DateOnly Appointmentdate { get; set; }

    public TimeOnly Appointmenttime { get; set; }

    public string? Reason { get; set; }

    public short? Status { get; set; }

    public DateTime? Createdat { get; set; }

    public DateTime? Updatedat { get; set; }

    public virtual User Doctor { get; set; } = null!;
}
