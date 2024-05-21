using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class InstrumentModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "InstrumentName")]
		public string InstrumentName { get; set; }

		[Display(Name = "ExpirationDate")]
		public DateTime? ExpirationDate { get; set; }

		public static InstrumentModel FromEntity(Instrument obj)
		{
			return obj == null ? null : new InstrumentModel
			{
				Id = obj.Id,
				InstrumentName = obj.InstrumentName,
				ExpirationDate = obj.ExpirationDate,
			};
		}

		public static Instrument ToEntity(InstrumentModel obj)
		{
			return obj == null ? null : new Instrument(obj.Id, obj.InstrumentName, obj.ExpirationDate);
		}

		public static List<InstrumentModel> FromEntitiesList(IEnumerable<Instrument> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Instrument> ToEntitiesList(IEnumerable<InstrumentModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
