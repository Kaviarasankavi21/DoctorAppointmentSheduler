using System;
using System.Collections.Generic;

namespace DoctorAppointmentScheduler.API.Models;

public partial class Occupation
{
    public Guid Occupationid { get; set; }

    public string Occupationname { get; set; } = null!;

    public bool? Isdeleted { get; set; }

    public virtual ICollection<Patientdetail> Patientdetails { get; set; } = new List<Patientdetail>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
