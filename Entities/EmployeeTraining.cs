using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class EmployeeTraining
	{
		public int Id { get; set; }
		public int? EmployeeId { get; set; }
		public string TrainingTopic { get; set; }
		public double? Duration { get; set; }
		public DateTime? Date { get; set; }

		public EmployeeTraining(int id, int? employeeId, string trainingTopic, double? duration, DateTime? date)
		{
			Id = id;
			EmployeeId = employeeId;
			TrainingTopic = trainingTopic;
			Duration = duration;
			Date = date;
		}
	}
}
