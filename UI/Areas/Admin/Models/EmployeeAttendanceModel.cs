using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class EmployeeAttendanceModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "EmployeeId")]
		public int? EmployeeId { get; set; }

		[Display(Name = "AttendanceDate")]
		public DateTime? AttendanceDate { get; set; }

		[Display(Name = "IsPresent")]
		public bool? IsPresent { get; set; }

		public static EmployeeAttendanceModel FromEntity(EmployeeAttendance obj)
		{
			return obj == null ? null : new EmployeeAttendanceModel
			{
				Id = obj.Id,
				EmployeeId = obj.EmployeeId,
				AttendanceDate = obj.AttendanceDate,
				IsPresent = obj.IsPresent,
			};
		}

		public static EmployeeAttendance ToEntity(EmployeeAttendanceModel obj)
		{
			return obj == null ? null : new EmployeeAttendance(obj.Id, obj.EmployeeId, obj.AttendanceDate,
				obj.IsPresent);
		}

		public static List<EmployeeAttendanceModel> FromEntitiesList(IEnumerable<EmployeeAttendance> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<EmployeeAttendance> ToEntitiesList(IEnumerable<EmployeeAttendanceModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
