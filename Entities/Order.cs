using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Order
	{
		public int Id { get; set; }
		public int? CustomerId { get; set; }
		public int? EmployeeId { get; set; }
		public DateTime? Date { get; set; }
		public string Status { get; set; }
		public int? TotalPrice { get; set; }

		public Order(int id, int? customerId, int? employeeId, DateTime? date, string status, int? totalPrice)
		{
			Id = id;
			CustomerId = customerId;
			EmployeeId = employeeId;
			Date = date;
			Status = status;
			TotalPrice = totalPrice;
		}
	}
}
