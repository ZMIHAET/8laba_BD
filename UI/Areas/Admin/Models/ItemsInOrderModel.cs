using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class ItemsInOrderModel
	{
		[Display(Name = "Id")]
		public int? Id { get; set; }

		[Display(Name = "MedicineId")]
		public int? MedicineId { get; set; }

		[Display(Name = "Quantity")]
		public int? Quantity { get; set; }

		public static ItemsInOrderModel FromEntity(ItemsInOrder obj)
		{
			return obj == null ? null : new ItemsInOrderModel
			{
				Id = obj.Id,
				MedicineId = obj.MedicineId,
				Quantity = obj.Quantity,
			};
		}

		public static ItemsInOrder ToEntity(ItemsInOrderModel obj)
		{
			return obj == null ? null : new ItemsInOrder(obj.Id, obj.MedicineId, obj.Quantity);
		}

		public static List<ItemsInOrderModel> FromEntitiesList(IEnumerable<ItemsInOrder> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<ItemsInOrder> ToEntitiesList(IEnumerable<ItemsInOrderModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
