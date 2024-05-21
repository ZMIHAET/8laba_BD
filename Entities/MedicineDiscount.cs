using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class MedicineDiscount
	{
		public int Id { get; set; }
		public int? MedicineId { get; set; }
		public double? Percentage { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }

		public MedicineDiscount(int id, int? medicineId, double? percentage, DateTime? startDate, DateTime? endDate)
		{
			Id = id;
			MedicineId = medicineId;
			Percentage = percentage;
			StartDate = startDate;
			EndDate = endDate;
		}
	}
}
