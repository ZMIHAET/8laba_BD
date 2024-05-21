using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class ItemsInOrder
{
    public int Id { get; set; }

    public int? MedicineId { get; set; }

    public int? Quantity { get; set; }

    public virtual Order Id1 { get; set; }

    public virtual Medicine IdNavigation { get; set; }
}
