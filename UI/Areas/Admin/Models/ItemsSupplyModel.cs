using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class ItemsSupplyModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "MedicineId")]
		public int? MedicineId { get; set; }

		[Display(Name = "MedicineSupplierId")]
		public int? MedicineSupplierId { get; set; }

		[Display(Name = "Quantity")]
		public int? Quantity { get; set; }

		[Display(Name = "UnitPrice")]
		public int? UnitPrice { get; set; }

		public static ItemsSupplyModel FromEntity(ItemsSupply obj)
		{
			return obj == null ? null : new ItemsSupplyModel
			{
				Id = obj.Id,
				MedicineId = obj.MedicineId,
				MedicineSupplierId = obj.MedicineSupplierId,
				Quantity = obj.Quantity,
				UnitPrice = obj.UnitPrice,
			};
		}

		public static ItemsSupply ToEntity(ItemsSupplyModel obj)
		{
			return obj == null ? null : new ItemsSupply(obj.Id, obj.MedicineId, obj.MedicineSupplierId, obj.Quantity,
				obj.UnitPrice);
		}

		public static List<ItemsSupplyModel> FromEntitiesList(IEnumerable<ItemsSupply> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<ItemsSupply> ToEntitiesList(IEnumerable<ItemsSupplyModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
