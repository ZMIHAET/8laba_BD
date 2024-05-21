using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Courier
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public string Phone { get; set; }
		public DateTime? EmploymentDate { get; set; }

		public Courier(int id, string fullName, string phone, DateTime? employmentDate)
		{
			Id = id;
			FullName = fullName;
			Phone = phone;
			EmploymentDate = employmentDate;
		}
	}
}
