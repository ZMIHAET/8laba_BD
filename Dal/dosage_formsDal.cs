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
	public class dosage_formsDal : BaseDal<DefaultDbContext, DosageForm, Entities.DosageForm, int, dosage_formsSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public dosage_formsDal()
		{
		}

		protected internal dosage_formsDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.DosageForm entity, DosageForm dbObject, bool exists)
		{
			dbObject.FormName = entity.FormName;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<DosageForm>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<DosageForm> dbObjects, dosage_formsSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.DosageForm>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<DosageForm> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<DosageForm, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.DosageForm, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.DosageForm ConvertDbObjectToEntity(DosageForm dbObject)
		{
			return dbObject == null ? null : new Entities.DosageForm(dbObject.Id, dbObject.FormName);
		}
	}
}
