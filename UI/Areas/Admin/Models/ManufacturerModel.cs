using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class ManufacturerModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "ManufacturerName")]
		public string ManufacturerName { get; set; }

		[Display(Name = "Address")]
		public string Address { get; set; }

		[Display(Name = "Phone")]
		public string Phone { get; set; }

		public static ManufacturerModel FromEntity(Manufacturer obj)
		{
			return obj == null ? null : new ManufacturerModel
			{
				Id = obj.Id,
				ManufacturerName = obj.ManufacturerName,
				Address = obj.Address,
				Phone = obj.Phone,
			};
		}

		public static Manufacturer ToEntity(ManufacturerModel obj)
		{
			return obj == null ? null : new Manufacturer(obj.Id, obj.ManufacturerName, obj.Address, obj.Phone);
		}

		public static List<ManufacturerModel> FromEntitiesList(IEnumerable<Manufacturer> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Manufacturer> ToEntitiesList(IEnumerable<ManufacturerModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
