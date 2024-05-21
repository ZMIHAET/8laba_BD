using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Order
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public int? EmployeeId { get; set; }

    public DateTime? Date { get; set; }

    public string Status { get; set; }

    public int? TotalPrice { get; set; }

    public virtual Delivery Delivery { get; set; }

    public virtual Employee Id1 { get; set; }

    public virtual Customer IdNavigation { get; set; }

    public virtual ItemsInOrder ItemsInOrder { get; set; }
}
