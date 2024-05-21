using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class MedicineReviewModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "MedicineId")]
		public int? MedicineId { get; set; }

		[Display(Name = "CustomerId")]
		public int? CustomerId { get; set; }

		[Display(Name = "Rating")]
		public double? Rating { get; set; }

		[Display(Name = "ReviewText")]
		public string ReviewText { get; set; }

		[Display(Name = "ReviewDate")]
		public DateTime? ReviewDate { get; set; }

		public static MedicineReviewModel FromEntity(MedicineReview obj)
		{
			return obj == null ? null : new MedicineReviewModel
			{
				Id = obj.Id,
				MedicineId = obj.MedicineId,
				CustomerId = obj.CustomerId,
				Rating = obj.Rating,
				ReviewText = obj.ReviewText,
				ReviewDate = obj.ReviewDate,
			};
		}

		public static MedicineReview ToEntity(MedicineReviewModel obj)
		{
			return obj == null ? null : new MedicineReview(obj.Id, obj.MedicineId, obj.CustomerId, obj.Rating,
				obj.ReviewText, obj.ReviewDate);
		}

		public static List<MedicineReviewModel> FromEntitiesList(IEnumerable<MedicineReview> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<MedicineReview> ToEntitiesList(IEnumerable<MedicineReviewModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
