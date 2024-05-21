using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Manufacturer
{
    public int Id { get; set; }

    public string ManufacturerName { get; set; }

    public string Address { get; set; }

    public string Phone { get; set; }

    public virtual Medicine Medicine { get; set; }
}
