using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class MedicineReview
	{
		public int Id { get; set; }
		public int? MedicineId { get; set; }
		public int? CustomerId { get; set; }
		public double? Rating { get; set; }
		public string ReviewText { get; set; }
		public DateTime? ReviewDate { get; set; }

		public MedicineReview(int id, int? medicineId, int? customerId, double? rating, string reviewText,
			DateTime? reviewDate)
		{
			Id = id;
			MedicineId = medicineId;
			CustomerId = customerId;
			Rating = rating;
			ReviewText = reviewText;
			ReviewDate = reviewDate;
		}
	}
}
