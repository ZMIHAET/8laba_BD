using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class OrderModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "CustomerId")]
		public int? CustomerId { get; set; }

		[Display(Name = "EmployeeId")]
		public int? EmployeeId { get; set; }

		[Display(Name = "Date")]
		public DateTime? Date { get; set; }

		[Display(Name = "Status")]
		public string Status { get; set; }

		[Display(Name = "TotalPrice")]
		public int? TotalPrice { get; set; }

		public static OrderModel FromEntity(Order obj)
		{
			return obj == null ? null : new OrderModel
			{
				Id = obj.Id,
				CustomerId = obj.CustomerId,
				EmployeeId = obj.EmployeeId,
				Date = obj.Date,
				Status = obj.Status,
				TotalPrice = obj.TotalPrice,
			};
		}

		public static Order ToEntity(OrderModel obj)
		{
			return obj == null ? null : new Order(obj.Id, obj.CustomerId, obj.EmployeeId, obj.Date, obj.Status,
				obj.TotalPrice);
		}

		public static List<OrderModel> FromEntitiesList(IEnumerable<Order> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Order> ToEntitiesList(IEnumerable<OrderModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
