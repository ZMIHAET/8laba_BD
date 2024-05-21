using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class ItemsInOrder
	{
		private int? id;

		public int Id { get; set; }
		public int? MedicineId { get; set; }
		public int? Quantity { get; set; }

		public ItemsInOrder(int id, int? medicineId, int? quantity)
		{
			Id = id;
			MedicineId = medicineId;
			Quantity = quantity;
		}

		public ItemsInOrder(int? id, int? medicineId, int? quantity)
		{
			this.id = id;
			MedicineId = medicineId;
			Quantity = quantity;
		}
	}
}
