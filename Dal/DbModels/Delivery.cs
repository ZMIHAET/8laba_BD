using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Delivery
{
    public int Id { get; set; }

    public int? MedicineId { get; set; }

    public int? CourierId { get; set; }

    public int? OrderId { get; set; }

    public DateTime? Date { get; set; }

    public double? Distance { get; set; }

    public virtual Medicine Id1 { get; set; }

    public virtual Order Id2 { get; set; }

    public virtual Courier IdNavigation { get; set; }
}
