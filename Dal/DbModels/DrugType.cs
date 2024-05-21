using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class DrugType
{
    public int Id { get; set; }

    public string TypeName { get; set; }

    public virtual Medication Medication { get; set; }
}
