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
	public class items_supplyDal : BaseDal<DefaultDbContext, ItemsSupply, Entities.ItemsSupply, int, items_supplySearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public items_supplyDal()
		{
		}

		protected internal items_supplyDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.ItemsSupply entity, ItemsSupply dbObject, bool exists)
		{
			dbObject.MedicineId = entity.MedicineId;
			dbObject.MedicineSupplierId = entity.MedicineSupplierId;
			dbObject.Quantity = entity.Quantity;
			dbObject.UnitPrice = entity.UnitPrice;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<ItemsSupply>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<ItemsSupply> dbObjects, items_supplySearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.ItemsSupply>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<ItemsSupply> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<ItemsSupply, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.ItemsSupply, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.ItemsSupply ConvertDbObjectToEntity(ItemsSupply dbObject)
		{
			return dbObject == null ? null : new Entities.ItemsSupply(dbObject.Id, dbObject.MedicineId,
				dbObject.MedicineSupplierId, dbObject.Quantity, dbObject.UnitPrice);
		}
	}
}
