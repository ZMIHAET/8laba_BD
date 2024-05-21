using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class MedicineTypeModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "TypeName")]
		public string TypeName { get; set; }

		[Display(Name = "Description")]
		public string Description { get; set; }

		public static MedicineTypeModel FromEntity(MedicineType obj)
		{
			return obj == null ? null : new MedicineTypeModel
			{
				Id = obj.Id,
				TypeName = obj.TypeName,
				Description = obj.Description,
			};
		}

		public static MedicineType ToEntity(MedicineTypeModel obj)
		{
			return obj == null ? null : new MedicineType(obj.Id, obj.TypeName, obj.Description);
		}

		public static List<MedicineTypeModel> FromEntitiesList(IEnumerable<MedicineType> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<MedicineType> ToEntitiesList(IEnumerable<MedicineTypeModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
