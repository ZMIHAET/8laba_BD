using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Supplier
{
    public int Id { get; set; }

    public string SupplierName { get; set; }

    public string Address { get; set; }

    public string Phone { get; set; }

    public virtual MedicineSupplier MedicineSupplier { get; set; }
}
