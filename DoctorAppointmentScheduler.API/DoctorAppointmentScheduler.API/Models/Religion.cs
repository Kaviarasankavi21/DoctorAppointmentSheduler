using System;
using System.Collections.Generic;

namespace DoctorAppointmentScheduler.API.Models;

public partial class Religion
{
    public Guid Religionid { get; set; }

    public string Religionname { get; set; } = null!;

    public bool? Isdeleted { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
