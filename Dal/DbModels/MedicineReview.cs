using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class MedicineReview
{
    public int Id { get; set; }

    public int? MedicineId { get; set; }

    public int? CustomerId { get; set; }

    public double? Rating { get; set; }

    public string ReviewText { get; set; }

    public DateTime? ReviewDate { get; set; }

    public virtual Medicine Id1 { get; set; }

    public virtual Customer IdNavigation { get; set; }
}
