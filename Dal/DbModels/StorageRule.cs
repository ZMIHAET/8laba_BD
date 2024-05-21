using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class StorageRule
{
    public int Id { get; set; }

    public string RuleName { get; set; }

    public string Description { get; set; }

    public virtual Medicine Medicine { get; set; }
}
