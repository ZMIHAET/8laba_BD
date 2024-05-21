using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class MedicineType
	{
		public int Id { get; set; }
		public string TypeName { get; set; }
		public string Description { get; set; }

		public MedicineType(int id, string typeName, string description)
		{
			Id = id;
			TypeName = typeName;
			Description = description;
		}
	}
}
