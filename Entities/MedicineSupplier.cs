using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class MedicineSupplier
	{
		public int Id { get; set; }
		public int? SupplierId { get; set; }
		public DateTime? SupplyDate { get; set; }
		public int? TotalPrice { get; set; }

		public MedicineSupplier(int id, int? supplierId, DateTime? supplyDate, int? totalPrice)
		{
			Id = id;
			SupplierId = supplierId;
			SupplyDate = supplyDate;
			TotalPrice = totalPrice;
		}
	}
}
