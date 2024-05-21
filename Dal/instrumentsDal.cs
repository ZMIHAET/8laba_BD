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
	public class instrumentsDal : BaseDal<DefaultDbContext, Instrument, Entities.Instrument, int, instrumentsSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public instrumentsDal()
		{
		}

		protected internal instrumentsDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Instrument entity, Instrument dbObject, bool exists)
		{
			dbObject.InstrumentName = entity.InstrumentName;
			dbObject.ExpirationDate = entity.ExpirationDate;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Instrument>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Instrument> dbObjects, instrumentsSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Instrument>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Instrument> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Instrument, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Instrument, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Instrument ConvertDbObjectToEntity(Instrument dbObject)
		{
			return dbObject == null ? null : new Entities.Instrument(dbObject.Id, dbObject.InstrumentName,
				dbObject.ExpirationDate);
		}
	}
}
