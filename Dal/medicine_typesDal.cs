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
	public class medicine_typesDal : BaseDal<DefaultDbContext, MedicineType, Entities.MedicineType, int, medicine_typesSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public medicine_typesDal()
		{
		}

		protected internal medicine_typesDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.MedicineType entity, MedicineType dbObject, bool exists)
		{
			dbObject.TypeName = entity.TypeName;
			dbObject.Description = entity.Description;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<MedicineType>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<MedicineType> dbObjects, medicine_typesSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.MedicineType>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<MedicineType> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<MedicineType, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.MedicineType, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.MedicineType ConvertDbObjectToEntity(MedicineType dbObject)
		{
			return dbObject == null ? null : new Entities.MedicineType(dbObject.Id, dbObject.TypeName,
				dbObject.Description);
		}
	}
}
