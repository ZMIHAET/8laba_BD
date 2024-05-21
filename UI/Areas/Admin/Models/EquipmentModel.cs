using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class EquipmentModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "EquipmentName")]
		public string EquipmentName { get; set; }

		[Display(Name = "ExpirationDate")]
		public DateTime? ExpirationDate { get; set; }

		public static EquipmentModel FromEntity(Equipment obj)
		{
			return obj == null ? null : new EquipmentModel
			{
				Id = obj.Id,
				EquipmentName = obj.EquipmentName,
				ExpirationDate = obj.ExpirationDate,
			};
		}

		public static Equipment ToEntity(EquipmentModel obj)
		{
			return obj == null ? null : new Equipment(obj.Id, obj.EquipmentName, obj.ExpirationDate);
		}

		public static List<EquipmentModel> FromEntitiesList(IEnumerable<Equipment> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Equipment> ToEntitiesList(IEnumerable<EquipmentModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
