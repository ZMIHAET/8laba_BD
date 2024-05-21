using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class EmployeeRole
{
    public int Id { get; set; }

    public string RoleName { get; set; }

    public virtual Employee Employee { get; set; }
}
