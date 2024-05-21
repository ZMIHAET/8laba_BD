using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class EmployeeAttendance
	{
		public int Id { get; set; }
		public int? EmployeeId { get; set; }
		public DateTime? AttendanceDate { get; set; }
		public bool? IsPresent { get; set; }

		public EmployeeAttendance(int id, int? employeeId, DateTime? attendanceDate, bool? isPresent)
		{
			Id = id;
			EmployeeId = employeeId;
			AttendanceDate = attendanceDate;
			IsPresent = isPresent;
		}
	}
}
