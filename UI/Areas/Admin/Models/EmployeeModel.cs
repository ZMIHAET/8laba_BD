using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class EmployeeModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "FullName")]
		public string FullName { get; set; }

		[Display(Name = "DateOfBirth")]
		public DateTime? DateOfBirth { get; set; }

		[Display(Name = "Phone")]
		public string Phone { get; set; }

		[Display(Name = "RoleId")]
		public int? RoleId { get; set; }

		[Display(Name = "HireDate")]
		public DateTime? HireDate { get; set; }

		[Display(Name = "Salary")]
		public int? Salary { get; set; }

		public static EmployeeModel FromEntity(Employee obj)
		{
			return obj == null ? null : new EmployeeModel
			{
				Id = obj.Id,
				FullName = obj.FullName,
				DateOfBirth = obj.DateOfBirth,
				Phone = obj.Phone,
				RoleId = obj.RoleId,
				HireDate = obj.HireDate,
				Salary = obj.Salary,
			};
		}

		public static Employee ToEntity(EmployeeModel obj)
		{
			return obj == null ? null : new Employee(obj.Id, obj.FullName, obj.DateOfBirth, obj.Phone, obj.RoleId,
				obj.HireDate, obj.Salary);
		}

		public static List<EmployeeModel> FromEntitiesList(IEnumerable<Employee> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Employee> ToEntitiesList(IEnumerable<EmployeeModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
