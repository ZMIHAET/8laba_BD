using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class MedicineModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "MedicineName")]
		public string MedicineName { get; set; }

		[Display(Name = "TypeId")]
		public int? TypeId { get; set; }

		[Display(Name = "StorageRuleId")]
		public int? StorageRuleId { get; set; }

		[Display(Name = "ExpiryDate")]
		public DateTime? ExpiryDate { get; set; }

		[Display(Name = "Price")]
		public int? Price { get; set; }

		[Display(Name = "Weight")]
		public int? Weight { get; set; }

		[Display(Name = "ManufacturerId")]
		public int? ManufacturerId { get; set; }

		[Display(Name = "QuantityOnStock")]
		public int? QuantityOnStock { get; set; }

		[Display(Name = "PrescriptionStatusName")]
		public string PrescriptionStatusName { get; set; }

		public static MedicineModel FromEntity(Medicine obj)
		{
			return obj == null ? null : new MedicineModel
			{
				Id = obj.Id,
				MedicineName = obj.MedicineName,
				TypeId = obj.TypeId,
				StorageRuleId = obj.StorageRuleId,
				ExpiryDate = obj.ExpiryDate,
				Price = obj.Price,
				Weight = obj.Weight,
				ManufacturerId = obj.ManufacturerId,
				QuantityOnStock = obj.QuantityOnStock,
				PrescriptionStatusName = obj.PrescriptionStatusName,
			};
		}

		public static Medicine ToEntity(MedicineModel obj)
		{
			return obj == null ? null : new Medicine(obj.Id, obj.MedicineName, obj.TypeId, obj.StorageRuleId,
				obj.ExpiryDate, obj.Price, obj.Weight, obj.ManufacturerId, obj.QuantityOnStock,
				obj.PrescriptionStatusName);
		}

		public static List<MedicineModel> FromEntitiesList(IEnumerable<Medicine> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Medicine> ToEntitiesList(IEnumerable<MedicineModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
