using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class CustomerModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "FullName")]
		public string FullName { get; set; }

		[Display(Name = "DateOfBirth")]
		public DateTime? DateOfBirth { get; set; }

		[Display(Name = "Phone")]
		public string Phone { get; set; }

		public static CustomerModel FromEntity(Customer obj)
		{
			return obj == null ? null : new CustomerModel
			{
				Id = obj.Id,
				FullName = obj.FullName,
				DateOfBirth = obj.DateOfBirth,
				Phone = obj.Phone,
			};
		}

		public static Customer ToEntity(CustomerModel obj)
		{
			return obj == null ? null : new Customer(obj.Id, obj.FullName, obj.DateOfBirth, obj.Phone);
		}

		public static List<CustomerModel> FromEntitiesList(IEnumerable<Customer> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Customer> ToEntitiesList(IEnumerable<CustomerModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
