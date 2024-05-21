using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class DosageFormModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "FormName")]
		public string FormName { get; set; }

		public static DosageFormModel FromEntity(DosageForm obj)
		{
			return obj == null ? null : new DosageFormModel
			{
				Id = obj.Id,
				FormName = obj.FormName,
			};
		}

		public static DosageForm ToEntity(DosageFormModel obj)
		{
			return obj == null ? null : new DosageForm(obj.Id, obj.FormName);
		}

		public static List<DosageFormModel> FromEntitiesList(IEnumerable<DosageForm> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<DosageForm> ToEntitiesList(IEnumerable<DosageFormModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
