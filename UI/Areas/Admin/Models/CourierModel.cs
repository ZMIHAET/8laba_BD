using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class CourierModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "FullName")]
		public string FullName { get; set; }

		[Display(Name = "Phone")]
		public string Phone { get; set; }

		[Display(Name = "EmploymentDate")]
		public DateTime? EmploymentDate { get; set; }

		public static CourierModel FromEntity(Courier obj)
		{
			return obj == null ? null : new CourierModel
			{
				Id = obj.Id,
				FullName = obj.FullName,
				Phone = obj.Phone,
				EmploymentDate = obj.EmploymentDate,
			};
		}

		public static Courier ToEntity(CourierModel obj)
		{
			return obj == null ? null : new Courier(obj.Id, obj.FullName, obj.Phone, obj.EmploymentDate);
		}

		public static List<CourierModel> FromEntitiesList(IEnumerable<Courier> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Courier> ToEntitiesList(IEnumerable<CourierModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
