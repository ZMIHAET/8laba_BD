using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Common.Enums;
using Common.Search;
using Dal.DbModels;

namespace Dal
{
	public class employee_trainingsDal : BaseDal<DefaultDbContext, EmployeeTraining, Entities.EmployeeTraining, int, employee_trainingsSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public employee_trainingsDal()
		{
		}

		protected internal employee_trainingsDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.EmployeeTraining entity, EmployeeTraining dbObject, bool exists)
		{
			dbObject.EmployeeId = entity.EmployeeId;
			dbObject.TrainingTopic = entity.TrainingTopic;
			dbObject.Duration = entity.Duration;
			dbObject.Date = entity.Date;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<EmployeeTraining>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<EmployeeTraining> dbObjects, employee_trainingsSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.EmployeeTraining>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<EmployeeTraining> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<EmployeeTraining, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.EmployeeTraining, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.EmployeeTraining ConvertDbObjectToEntity(EmployeeTraining dbObject)
		{
			return dbObject == null ? null : new Entities.EmployeeTraining(dbObject.Id, dbObject.EmployeeId,
				dbObject.TrainingTopic, dbObject.Duration, dbObject.Date);
		}
	}
}
