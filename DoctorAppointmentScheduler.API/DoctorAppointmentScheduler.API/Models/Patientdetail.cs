using System;
using System.Collections.Generic;

namespace DoctorAppointmentScheduler.API.Models;

public partial class Patientdetail
{
    public Guid Patientid { get; set; }

    public Guid? Titleid { get; set; }

    public string Name { get; set; } = null!;

    public short? Gender { get; set; }

    public DateOnly? Dob { get; set; }

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public Guid? Maritalstatusid { get; set; }

    public Guid? Occupationid { get; set; }

    public Guid? Nationalityid { get; set; }

    public string? State { get; set; }

    public string? Pincode { get; set; }

    public string? Address { get; set; }

    public bool? Isactive { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public int? Age { get; set; }

    public DateOnly? Visitdate { get; set; }

    public TimeOnly? Visittime { get; set; }

    public virtual Maritalstatus? Maritalstatus { get; set; }

    public virtual Country? Nationality { get; set; }

    public virtual Occupation? Occupation { get; set; }

    public virtual Title? Title { get; set; }
}
