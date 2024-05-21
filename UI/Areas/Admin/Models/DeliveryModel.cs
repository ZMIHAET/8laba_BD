using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class DeliveryModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "MedicineId")]
		public int? MedicineId { get; set; }

		[Display(Name = "CourierId")]
		public int? CourierId { get; set; }

		[Display(Name = "OrderId")]
		public int? OrderId { get; set; }

		[Display(Name = "Date")]
		public DateTime? Date { get; set; }

		[Display(Name = "Distance")]
		public double? Distance { get; set; }

		public static DeliveryModel FromEntity(Delivery obj)
		{
			return obj == null ? null : new DeliveryModel
			{
				Id = obj.Id,
				MedicineId = obj.MedicineId,
				CourierId = obj.CourierId,
				OrderId = obj.OrderId,
				Date = obj.Date,
				Distance = obj.Distance,
			};
		}

		public static Delivery ToEntity(DeliveryModel obj)
		{
			return obj == null ? null : new Delivery(obj.Id, obj.MedicineId, obj.CourierId, obj.OrderId, obj.Date,
				obj.Distance);
		}

		public static List<DeliveryModel> FromEntitiesList(IEnumerable<Delivery> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Delivery> ToEntitiesList(IEnumerable<DeliveryModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
