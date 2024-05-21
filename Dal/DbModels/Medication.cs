using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Medication
{
    public int Id { get; set; }

    public int? FormId { get; set; }

    public int? DrugTypeId { get; set; }

    public bool? Prescription { get; set; }

    public virtual DrugType Id1 { get; set; }

    public virtual DosageForm IdNavigation { get; set; }

    public virtual MedicineType MedicineType { get; set; }
}
