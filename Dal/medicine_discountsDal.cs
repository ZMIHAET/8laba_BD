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
	public class medicine_discountsDal : BaseDal<DefaultDbContext, MedicineDiscount, Entities.MedicineDiscount, int, medicine_discountsSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public medicine_discountsDal()
		{
		}

		protected internal medicine_discountsDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.MedicineDiscount entity, MedicineDiscount dbObject, bool exists)
		{
			dbObject.MedicineId = entity.MedicineId;
			dbObject.Percentage = entity.Percentage;
			dbObject.StartDate = entity.StartDate;
			dbObject.EndDate = entity.EndDate;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<MedicineDiscount>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<MedicineDiscount> dbObjects, medicine_discountsSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.MedicineDiscount>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<MedicineDiscount> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<MedicineDiscount, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.MedicineDiscount, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.MedicineDiscount ConvertDbObjectToEntity(MedicineDiscount dbObject)
		{
			return dbObject == null ? null : new Entities.MedicineDiscount(dbObject.Id, dbObject.MedicineId,
				dbObject.Percentage, dbObject.StartDate, dbObject.EndDate);
		}
	}
}
