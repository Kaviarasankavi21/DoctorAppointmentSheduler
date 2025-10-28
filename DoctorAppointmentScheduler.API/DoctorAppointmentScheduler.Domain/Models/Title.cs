using System;
using System.Collections.Generic;

namespace DoctorAppointmentScheduler.Domain.Models;

public partial class Title
{
    public Guid Titleid { get; set; }

    public string Titlename { get; set; } = null!;

    public bool? Isdeleted { get; set; }

    public virtual ICollection<Patientdetail> Patientdetails { get; set; } = new List<Patientdetail>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
