using System;
using System.Collections.Generic;

namespace DoctorAppointmentScheduler.Domain.Models;

public partial class Maritalstatus
{
    public Guid Maritalstatusid { get; set; }

    public string Maritalstatus1 { get; set; } = null!;

    public bool? Isdeleted { get; set; }

    public virtual ICollection<Patientdetail> Patientdetails { get; set; } = new List<Patientdetail>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
