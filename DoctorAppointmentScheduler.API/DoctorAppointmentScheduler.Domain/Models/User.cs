using System;
using System.Collections.Generic;

namespace DoctorAppointmentScheduler.Domain.Models;

public partial class User
{
    public Guid Userid { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string? Specialization { get; set; }

    public string? Gender { get; set; }

    public DateOnly? Dateofbirth { get; set; }

    public string Phonenumber { get; set; } = null!;

    public string? Address { get; set; }

    public string Username { get; set; } = null!;

    public string Hashedpassword { get; set; } = null!;

    public string Role { get; set; } = null!;

    public int? Yearsofexperience { get; set; }

    public string? Qualification { get; set; }

    public decimal? Consultationfee { get; set; }

    public TimeOnly? Availabilitystarttime { get; set; }

    public TimeOnly? Availabilityendtime { get; set; }

    public bool? Isactive { get; set; }

    public bool? Isdelete { get; set; }

    public Guid? Titleid { get; set; }

    public Guid? Countryid { get; set; }

    public Guid? Relationshipid { get; set; }

    public Guid? Occupationid { get; set; }

    public Guid? Religionid { get; set; }

    public Guid? Maritalstatusid { get; set; }

    public virtual ICollection<Appointment> AppointmentDoctors { get; set; } = new List<Appointment>();

    public virtual ICollection<Appointment> AppointmentPatients { get; set; } = new List<Appointment>();

    public virtual Country? Country { get; set; }

    public virtual Maritalstatus? Maritalstatus { get; set; }

    public virtual Occupation? Occupation { get; set; }

    public virtual Relationship? Relationship { get; set; }

    public virtual Religion? Religion { get; set; }

    public virtual Title? Title { get; set; }
}
