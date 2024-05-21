using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class MedicineSupplierModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "SupplierId")]
		public int? SupplierId { get; set; }

		[Display(Name = "SupplyDate")]
		public DateTime? SupplyDate { get; set; }

		[Display(Name = "TotalPrice")]
		public int? TotalPrice { get; set; }

		public static MedicineSupplierModel FromEntity(MedicineSupplier obj)
		{
			return obj == null ? null : new MedicineSupplierModel
			{
				Id = obj.Id,
				SupplierId = obj.SupplierId,
				SupplyDate = obj.SupplyDate,
				TotalPrice = obj.TotalPrice,
			};
		}

		public static MedicineSupplier ToEntity(MedicineSupplierModel obj)
		{
			return obj == null ? null : new MedicineSupplier(obj.Id, obj.SupplierId, obj.SupplyDate, obj.TotalPrice);
		}

		public static List<MedicineSupplierModel> FromEntitiesList(IEnumerable<MedicineSupplier> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<MedicineSupplier> ToEntitiesList(IEnumerable<MedicineSupplierModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
