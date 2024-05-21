using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Customer
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string Phone { get; set; }

		public Customer(int id, string fullName, DateTime? dateOfBirth, string phone)
		{
			Id = id;
			FullName = fullName;
			DateOfBirth = dateOfBirth;
			Phone = phone;
		}
	}
}
