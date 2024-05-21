using System;

namespace UI.Areas.Public.Models
{
	public class OrderInfoViewModel
	{
		public int Id { get; set; }
		public int CustomerId { get; set; }
		public int EmployeeId { get; set; }
		public DateTime Date { get; set; }
		public string Status { get; set; }
		public int TotalPrice { get; set; }
		public int Id_2 { get; set; }
		public int MedicineId { get; set; }
		public int CourierId { get; set; }
		public int OrderId { get; set; }
		public DateTime Date_2 { get; set; }
		public float Distance { get; set; }


	}
}