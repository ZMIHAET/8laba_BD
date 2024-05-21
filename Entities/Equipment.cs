using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Equipment
	{
		public int Id { get; set; }
		public string EquipmentName { get; set; }
		public DateTime? ExpirationDate { get; set; }

		public Equipment(int id, string equipmentName, DateTime? expirationDate)
		{
			Id = id;
			EquipmentName = equipmentName;
			ExpirationDate = expirationDate;
		}
	}
}
