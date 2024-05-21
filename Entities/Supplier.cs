using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Supplier
	{
		public int Id { get; set; }
		public string SupplierName { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }

		public Supplier(int id, string supplierName, string address, string phone)
		{
			Id = id;
			SupplierName = supplierName;
			Address = address;
			Phone = phone;
		}
	}
}
