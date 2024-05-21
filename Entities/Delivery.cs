using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Delivery
	{
		public int Id { get; set; }
		public int? MedicineId { get; set; }
		public int? CourierId { get; set; }
		public int? OrderId { get; set; }
		public DateTime? Date { get; set; }
		public double? Distance { get; set; }

		public Delivery(int id, int? medicineId, int? courierId, int? orderId, DateTime? date, double? distance)
		{
			Id = id;
			MedicineId = medicineId;
			CourierId = courierId;
			OrderId = orderId;
			Date = date;
			Distance = distance;
		}
	}
}
