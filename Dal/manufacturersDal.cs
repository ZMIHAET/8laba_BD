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
	public class manufacturersDal : BaseDal<DefaultDbContext, Manufacturer, Entities.Manufacturer, int, manufacturersSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public manufacturersDal()
		{
		}

		protected internal manufacturersDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Manufacturer entity, Manufacturer dbObject, bool exists)
		{
			dbObject.ManufacturerName = entity.ManufacturerName;
			dbObject.Address = entity.Address;
			dbObject.Phone = entity.Phone;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Manufacturer>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Manufacturer> dbObjects, manufacturersSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Manufacturer>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Manufacturer> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Manufacturer, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Manufacturer, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Manufacturer ConvertDbObjectToEntity(Manufacturer dbObject)
		{
			return dbObject == null ? null : new Entities.Manufacturer(dbObject.Id, dbObject.ManufacturerName,
				dbObject.Address, dbObject.Phone);
		}
	}
}
