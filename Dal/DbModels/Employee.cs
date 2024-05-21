using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Employee
{
    public int Id { get; set; }

    public string FullName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string Phone { get; set; }

    public int? RoleId { get; set; }

    public DateTime? HireDate { get; set; }

    public int? Salary { get; set; }

    public virtual EmployeeAttendance EmployeeAttendance { get; set; }

    public virtual EmployeeTraining EmployeeTraining { get; set; }

    public virtual EmployeeRole IdNavigation { get; set; }

    public virtual Order Order { get; set; }
}
