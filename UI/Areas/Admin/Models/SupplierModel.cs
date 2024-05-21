using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class SupplierModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "SupplierName")]
		public string SupplierName { get; set; }

		[Display(Name = "Address")]
		public string Address { get; set; }

		[Display(Name = "Phone")]
		public string Phone { get; set; }

		public static SupplierModel FromEntity(Supplier obj)
		{
			return obj == null ? null : new SupplierModel
			{
				Id = obj.Id,
				SupplierName = obj.SupplierName,
				Address = obj.Address,
				Phone = obj.Phone,
			};
		}

		public static Supplier ToEntity(SupplierModel obj)
		{
			return obj == null ? null : new Supplier(obj.Id, obj.SupplierName, obj.Address, obj.Phone);
		}

		public static List<SupplierModel> FromEntitiesList(IEnumerable<Supplier> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Supplier> ToEntitiesList(IEnumerable<SupplierModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
