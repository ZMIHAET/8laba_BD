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
	public class medicationsDal : BaseDal<DefaultDbContext, Medication, Entities.Medication, int, medicationsSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public medicationsDal()
		{
		}

		protected internal medicationsDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Medication entity, Medication dbObject, bool exists)
		{
			dbObject.FormId = entity.FormId;
			dbObject.DrugTypeId = entity.DrugTypeId;
			dbObject.Prescription = entity.Prescription;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Medication>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Medication> dbObjects, medicationsSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Medication>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Medication> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Medication, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Medication, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Medication ConvertDbObjectToEntity(Medication dbObject)
		{
			return dbObject == null ? null : new Entities.Medication(dbObject.Id, dbObject.FormId, dbObject.DrugTypeId,
				dbObject.Prescription);
		}
	}
}
