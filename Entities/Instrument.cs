using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Instrument
	{
		public int Id { get; set; }
		public string InstrumentName { get; set; }
		public DateTime? ExpirationDate { get; set; }

		public Instrument(int id, string instrumentName, DateTime? expirationDate)
		{
			Id = id;
			InstrumentName = instrumentName;
			ExpirationDate = expirationDate;
		}
	}
}
