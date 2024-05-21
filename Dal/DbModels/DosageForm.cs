using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class DosageForm
{
    public int Id { get; set; }

    public string FormName { get; set; }

    public virtual Medication Medication { get; set; }
}
