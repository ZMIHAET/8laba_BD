using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Courier
{
    public int Id { get; set; }

    public string FullName { get; set; }

    public string Phone { get; set; }

    public DateTime? EmploymentDate { get; set; }

    public virtual Delivery Delivery { get; set; }
}
