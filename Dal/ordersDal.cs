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
	public class ordersDal : BaseDal<DefaultDbContext, Order, Entities.Order, int, ordersSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public ordersDal()
		{
		}

		protected internal ordersDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Order entity, Order dbObject, bool exists)
		{
			dbObject.CustomerId = entity.CustomerId;
			dbObject.EmployeeId = entity.EmployeeId;
			dbObject.Date = entity.Date;
			dbObject.Status = entity.Status;
			dbObject.TotalPrice = entity.TotalPrice;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Order>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Order> dbObjects, ordersSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Order>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Order> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Order, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Order, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Order ConvertDbObjectToEntity(Order dbObject)
		{
			return dbObject == null ? null : new Entities.Order(dbObject.Id, dbObject.CustomerId, dbObject.EmployeeId,
				dbObject.Date, dbObject.Status, dbObject.TotalPrice);
		}
	}
}
