using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class ItemsSupply
	{
		public int Id { get; set; }
		public int? MedicineId { get; set; }
		public int? MedicineSupplierId { get; set; }
		public int? Quantity { get; set; }
		public int? UnitPrice { get; set; }

		public ItemsSupply(int id, int? medicineId, int? medicineSupplierId, int? quantity, int? unitPrice)
		{
			Id = id;
			MedicineId = medicineId;
			MedicineSupplierId = medicineSupplierId;
			Quantity = quantity;
			UnitPrice = unitPrice;
		}
	}
}
