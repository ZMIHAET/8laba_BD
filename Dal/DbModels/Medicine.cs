using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Medicine
{
    public int Id { get; set; }

    public string MedicineName { get; set; }

    public int? TypeId { get; set; }

    public int? StorageRuleId { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public int? Price { get; set; }

    public int? Weight { get; set; }

    public int? ManufacturerId { get; set; }

    public int? QuantityOnStock { get; set; }

    public string PrescriptionStatusName { get; set; }

    public virtual Delivery Delivery { get; set; }

    public virtual MedicineType Id1 { get; set; }

    public virtual StorageRule Id2 { get; set; }

    public virtual Manufacturer IdNavigation { get; set; }

    public virtual ItemsInOrder ItemsInOrder { get; set; }

    public virtual ItemsSupply ItemsSupply { get; set; }

    public virtual MedicineDiscount MedicineDiscount { get; set; }

    public virtual MedicineReview MedicineReview { get; set; }
}
