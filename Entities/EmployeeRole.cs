using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class EmployeeRole
	{
		public int Id { get; set; }
		public string RoleName { get; set; }

		public EmployeeRole(int id, string roleName)
		{
			Id = id;
			RoleName = roleName;
		}
	}
}
