using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class StorageRule
	{
		public int Id { get; set; }
		public string RuleName { get; set; }
		public string Description { get; set; }

		public StorageRule(int id, string ruleName, string description)
		{
			Id = id;
			RuleName = ruleName;
			Description = description;
		}
	}
}
