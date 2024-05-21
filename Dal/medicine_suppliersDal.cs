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
	public class medicine_suppliersDal : BaseDal<DefaultDbContext, MedicineSupplier, Entities.MedicineSupplier, int, medicine_suppliersSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public medicine_suppliersDal()
		{
		}

		protected internal medicine_suppliersDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.MedicineSupplier entity, MedicineSupplier dbObject, bool exists)
		{
			dbObject.SupplierId = entity.SupplierId;
			dbObject.SupplyDate = entity.SupplyDate;
			dbObject.TotalPrice = entity.TotalPrice;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<MedicineSupplier>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<MedicineSupplier> dbObjects, medicine_suppliersSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.MedicineSupplier>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<MedicineSupplier> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<MedicineSupplier, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.MedicineSupplier, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.MedicineSupplier ConvertDbObjectToEntity(MedicineSupplier dbObject)
		{
			return dbObject == null ? null : new Entities.MedicineSupplier(dbObject.Id, dbObject.SupplierId,
				dbObject.SupplyDate, dbObject.TotalPrice);
		}
	}
}
