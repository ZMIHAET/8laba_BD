using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Customer
{
    public int Id { get; set; }

    public string FullName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string Phone { get; set; }

    public virtual MedicineReview MedicineReview { get; set; }

    public virtual Order Order { get; set; }
}
