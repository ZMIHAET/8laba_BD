using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Employee
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string Phone { get; set; }
		public int? RoleId { get; set; }
		public DateTime? HireDate { get; set; }
		public int? Salary { get; set; }

		public Employee(int id, string fullName, DateTime? dateOfBirth, string phone, int? roleId, DateTime? hireDate,
			int? salary)
		{
			Id = id;
			FullName = fullName;
			DateOfBirth = dateOfBirth;
			Phone = phone;
			RoleId = roleId;
			HireDate = hireDate;
			Salary = salary;
		}
	}
}
