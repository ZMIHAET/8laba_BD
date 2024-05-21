using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class EmployeeAttendance
{
    public int Id { get; set; }

    public int? EmployeeId { get; set; }

    public DateTime? AttendanceDate { get; set; }

    public bool? IsPresent { get; set; }

    public virtual Employee IdNavigation { get; set; }
}
