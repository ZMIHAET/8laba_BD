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
	public class items_in_orderDal : BaseDal<DefaultDbContext, ItemsInOrder, Entities.ItemsInOrder, int, items_in_orderSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public items_in_orderDal()
		{
		}

		protected internal items_in_orderDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.ItemsInOrder entity, ItemsInOrder dbObject, bool exists)
		{
			dbObject.MedicineId = entity.MedicineId;
			dbObject.Quantity = entity.Quantity;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<ItemsInOrder>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<ItemsInOrder> dbObjects, items_in_orderSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.ItemsInOrder>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<ItemsInOrder> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<ItemsInOrder, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.ItemsInOrder, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.ItemsInOrder ConvertDbObjectToEntity(ItemsInOrder dbObject)
		{
			return dbObject == null ? null : new Entities.ItemsInOrder(dbObject.Id, dbObject.MedicineId,
				dbObject.Quantity);
		}
	}
}
