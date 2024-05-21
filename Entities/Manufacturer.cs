using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Manufacturer
	{
		public int Id { get; set; }
		public string ManufacturerName { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }

		public Manufacturer(int id, string manufacturerName, string address, string phone)
		{
			Id = id;
			ManufacturerName = manufacturerName;
			Address = address;
			Phone = phone;
		}
	}
}
