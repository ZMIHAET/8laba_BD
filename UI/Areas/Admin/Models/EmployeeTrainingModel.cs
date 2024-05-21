using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class EmployeeTrainingModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "EmployeeId")]
		public int? EmployeeId { get; set; }

		[Display(Name = "TrainingTopic")]
		public string TrainingTopic { get; set; }

		[Display(Name = "Duration")]
		public double? Duration { get; set; }

		[Display(Name = "Date")]
		public DateTime? Date { get; set; }

		public static EmployeeTrainingModel FromEntity(EmployeeTraining obj)
		{
			return obj == null ? null : new EmployeeTrainingModel
			{
				Id = obj.Id,
				EmployeeId = obj.EmployeeId,
				TrainingTopic = obj.TrainingTopic,
				Duration = obj.Duration,
				Date = obj.Date,
			};
		}

		public static EmployeeTraining ToEntity(EmployeeTrainingModel obj)
		{
			return obj == null ? null : new EmployeeTraining(obj.Id, obj.EmployeeId, obj.TrainingTopic, obj.Duration,
				obj.Date);
		}

		public static List<EmployeeTrainingModel> FromEntitiesList(IEnumerable<EmployeeTraining> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<EmployeeTraining> ToEntitiesList(IEnumerable<EmployeeTrainingModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
