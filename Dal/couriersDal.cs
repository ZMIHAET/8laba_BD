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
	public class couriersDal : BaseDal<DefaultDbContext, Courier, Entities.Courier, int, couriersSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public couriersDal()
		{
		}

		protected internal couriersDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Courier entity, Courier dbObject, bool exists)
		{
			dbObject.FullName = entity.FullName;
			dbObject.Phone = entity.Phone;
			dbObject.EmploymentDate = entity.EmploymentDate;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Courier>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Courier> dbObjects, couriersSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Courier>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Courier> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Courier, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Courier, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Courier ConvertDbObjectToEntity(Courier dbObject)
		{
			return dbObject == null ? null : new Entities.Courier(dbObject.Id, dbObject.FullName, dbObject.Phone,
				dbObject.EmploymentDate);
		}
	}
}
