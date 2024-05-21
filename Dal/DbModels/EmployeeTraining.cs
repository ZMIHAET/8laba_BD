using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class EmployeeTraining
{
    public int Id { get; set; }

    public int? EmployeeId { get; set; }

    public string TrainingTopic { get; set; }

    public double? Duration { get; set; }

    public DateTime? Date { get; set; }

    public virtual Employee IdNavigation { get; set; }
}
