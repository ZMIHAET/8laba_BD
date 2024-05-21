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
	public class medicinesDal : BaseDal<DefaultDbContext, Medicine, Entities.Medicine, int, medicinesSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public medicinesDal()
		{
		}

		protected internal medicinesDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Medicine entity, Medicine dbObject, bool exists)
		{
			dbObject.MedicineName = entity.MedicineName;
			dbObject.TypeId = entity.TypeId;
			dbObject.StorageRuleId = entity.StorageRuleId;
			dbObject.ExpiryDate = entity.ExpiryDate;
			dbObject.Price = entity.Price;
			dbObject.Weight = entity.Weight;
			dbObject.ManufacturerId = entity.ManufacturerId;
			dbObject.QuantityOnStock = entity.QuantityOnStock;
			dbObject.PrescriptionStatusName = entity.PrescriptionStatusName;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Medicine>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Medicine> dbObjects, medicinesSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Medicine>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Medicine> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Medicine, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Medicine, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Medicine ConvertDbObjectToEntity(Medicine dbObject)
		{
			return dbObject == null ? null : new Entities.Medicine(dbObject.Id, dbObject.MedicineName, dbObject.TypeId,
				dbObject.StorageRuleId, dbObject.ExpiryDate, dbObject.Price, dbObject.Weight, dbObject.ManufacturerId,
				dbObject.QuantityOnStock, dbObject.PrescriptionStatusName);
		}
	}
}
