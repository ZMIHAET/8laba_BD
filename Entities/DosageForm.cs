using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class DosageForm
	{
		public int Id { get; set; }
		public string FormName { get; set; }

		public DosageForm(int id, string formName)
		{
			Id = id;
			FormName = formName;
		}
	}
}
