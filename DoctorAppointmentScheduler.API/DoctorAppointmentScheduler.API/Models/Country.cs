using System;
using System.Collections.Generic;

namespace DoctorAppointmentScheduler.API.Models;

public partial class Country
{
    public Guid Countryid { get; set; }

    public string Countryname { get; set; } = null!;

    public bool? Isdeleted { get; set; }

    public virtual ICollection<Patientdetail> Patientdetails { get; set; } = new List<Patientdetail>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
