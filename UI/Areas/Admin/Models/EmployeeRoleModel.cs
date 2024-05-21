using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class EmployeeRoleModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "RoleName")]
		public string RoleName { get; set; }

		public static EmployeeRoleModel FromEntity(EmployeeRole obj)
		{
			return obj == null ? null : new EmployeeRoleModel
			{
				Id = obj.Id,
				RoleName = obj.RoleName,
			};
		}

		public static EmployeeRole ToEntity(EmployeeRoleModel obj)
		{
			return obj == null ? null : new EmployeeRole(obj.Id, obj.RoleName);
		}

		public static List<EmployeeRoleModel> FromEntitiesList(IEnumerable<EmployeeRole> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<EmployeeRole> ToEntitiesList(IEnumerable<EmployeeRoleModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
