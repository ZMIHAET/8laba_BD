using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class MedicationModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "FormId")]
		public int? FormId { get; set; }

		[Display(Name = "DrugTypeId")]
		public int? DrugTypeId { get; set; }

		[Display(Name = "Prescription")]
		public bool? Prescription { get; set; }

		public static MedicationModel FromEntity(Medication obj)
		{
			return obj == null ? null : new MedicationModel
			{
				Id = obj.Id,
				FormId = obj.FormId,
				DrugTypeId = obj.DrugTypeId,
				Prescription = obj.Prescription,
			};
		}

		public static Medication ToEntity(MedicationModel obj)
		{
			return obj == null ? null : new Medication(obj.Id, obj.FormId, obj.DrugTypeId, obj.Prescription);
		}

		public static List<MedicationModel> FromEntitiesList(IEnumerable<Medication> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Medication> ToEntitiesList(IEnumerable<MedicationModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
