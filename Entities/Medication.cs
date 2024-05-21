using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Medication
	{
		public int Id { get; set; }
		public int? FormId { get; set; }
		public int? DrugTypeId { get; set; }
		public bool? Prescription { get; set; }

		public Medication(int id, int? formId, int? drugTypeId, bool? prescription)
		{
			Id = id;
			FormId = formId;
			DrugTypeId = drugTypeId;
			Prescription = prescription;
		}
	}
}
