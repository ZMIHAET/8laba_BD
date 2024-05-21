using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class DrugType
	{
		public int Id { get; set; }
		public string TypeName { get; set; }

		public DrugType(int id, string typeName)
		{
			Id = id;
			TypeName = typeName;
		}
	}
}
