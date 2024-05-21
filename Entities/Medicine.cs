using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Medicine
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

		public Medicine(int id, string medicineName, int? typeId, int? storageRuleId, DateTime? expiryDate, int? price,
			int? weight, int? manufacturerId, int? quantityOnStock, string prescriptionStatusName)
		{
			Id = id;
			MedicineName = medicineName;
			TypeId = typeId;
			StorageRuleId = storageRuleId;
			ExpiryDate = expiryDate;
			Price = price;
			Weight = weight;
			ManufacturerId = manufacturerId;
			QuantityOnStock = quantityOnStock;
			PrescriptionStatusName = prescriptionStatusName;
		}
	}
}
