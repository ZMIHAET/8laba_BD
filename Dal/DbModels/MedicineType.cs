using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class MedicineType
{
    public int Id { get; set; }

    public string TypeName { get; set; }

    public string Description { get; set; }

    public virtual Instrument Id1 { get; set; }

    public virtual Medication Id2 { get; set; }

    public virtual Equipment IdNavigation { get; set; }

    public virtual Medicine Medicine { get; set; }
}
