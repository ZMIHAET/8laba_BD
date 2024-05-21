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
	public class deliveriesDal : BaseDal<DefaultDbContext, Delivery, Entities.Delivery, int, deliveriesSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public deliveriesDal()
		{
		}

		protected internal deliveriesDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Delivery entity, Delivery dbObject, bool exists)
		{
			dbObject.MedicineId = entity.MedicineId;
			dbObject.CourierId = entity.CourierId;
			dbObject.OrderId = entity.OrderId;
			dbObject.Date = entity.Date;
			dbObject.Distance = entity.Distance;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Delivery>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Delivery> dbObjects, deliveriesSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Delivery>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Delivery> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Delivery, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Delivery, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Delivery ConvertDbObjectToEntity(Delivery dbObject)
		{
			return dbObject == null ? null : new Entities.Delivery(dbObject.Id, dbObject.MedicineId,
				dbObject.CourierId, dbObject.OrderId, dbObject.Date, dbObject.Distance);
		}
	}
}
