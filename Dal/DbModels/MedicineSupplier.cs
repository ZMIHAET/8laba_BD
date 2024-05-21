using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class MedicineSupplier
{
    public int Id { get; set; }

    public int? SupplierId { get; set; }

    public DateTime? SupplyDate { get; set; }

    public int? TotalPrice { get; set; }

    public virtual Supplier IdNavigation { get; set; }

    public virtual ItemsSupply ItemsSupply { get; set; }
}
