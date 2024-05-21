using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class MedicineDiscount
{
    public int Id { get; set; }

    public int? MedicineId { get; set; }

    public double? Percentage { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual Medicine IdNavigation { get; set; }
}
