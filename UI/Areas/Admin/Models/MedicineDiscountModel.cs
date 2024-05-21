using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class MedicineDiscountModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "MedicineId")]
		public int? MedicineId { get; set; }

		[Display(Name = "Percentage")]
		public double? Percentage { get; set; }

		[Display(Name = "StartDate")]
		public DateTime? StartDate { get; set; }

		[Display(Name = "EndDate")]
		public DateTime? EndDate { get; set; }

		public static MedicineDiscountModel FromEntity(MedicineDiscount obj)
		{
			return obj == null ? null : new MedicineDiscountModel
			{
				Id = obj.Id,
				MedicineId = obj.MedicineId,
				Percentage = obj.Percentage,
				StartDate = obj.StartDate,
				EndDate = obj.EndDate,
			};
		}

		public static MedicineDiscount ToEntity(MedicineDiscountModel obj)
		{
			return obj == null ? null : new MedicineDiscount(obj.Id, obj.MedicineId, obj.Percentage, obj.StartDate,
				obj.EndDate);
		}

		public static List<MedicineDiscountModel> FromEntitiesList(IEnumerable<MedicineDiscount> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<MedicineDiscount> ToEntitiesList(IEnumerable<MedicineDiscountModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
