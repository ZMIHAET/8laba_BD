using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Instrument
{
    public int Id { get; set; }

    public string InstrumentName { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public virtual MedicineType MedicineType { get; set; }
}
