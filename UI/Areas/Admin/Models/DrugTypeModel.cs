using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class DrugTypeModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "TypeName")]
		public string TypeName { get; set; }

		public static DrugTypeModel FromEntity(DrugType obj)
		{
			return obj == null ? null : new DrugTypeModel
			{
				Id = obj.Id,
				TypeName = obj.TypeName,
			};
		}

		public static DrugType ToEntity(DrugTypeModel obj)
		{
			return obj == null ? null : new DrugType(obj.Id, obj.TypeName);
		}

		public static List<DrugTypeModel> FromEntitiesList(IEnumerable<DrugType> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<DrugType> ToEntitiesList(IEnumerable<DrugTypeModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
