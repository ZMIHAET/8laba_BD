using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class StorageRuleModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "RuleName")]
		public string RuleName { get; set; }

		[Display(Name = "Description")]
		public string Description { get; set; }

		public static StorageRuleModel FromEntity(StorageRule obj)
		{
			return obj == null ? null : new StorageRuleModel
			{
				Id = obj.Id,
				RuleName = obj.RuleName,
				Description = obj.Description,
			};
		}

		public static StorageRule ToEntity(StorageRuleModel obj)
		{
			return obj == null ? null : new StorageRule(obj.Id, obj.RuleName, obj.Description);
		}

		public static List<StorageRuleModel> FromEntitiesList(IEnumerable<StorageRule> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<StorageRule> ToEntitiesList(IEnumerable<StorageRuleModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
