using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Equipment
{
    public int Id { get; set; }

    public string EquipmentName { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public virtual MedicineType MedicineType { get; set; }
}
