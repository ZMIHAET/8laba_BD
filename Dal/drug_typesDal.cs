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
	public class drug_typesDal : BaseDal<DefaultDbContext, DrugType, Entities.DrugType, int, drug_typesSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public drug_typesDal()
		{
		}

		protected internal drug_typesDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.DrugType entity, DrugType dbObject, bool exists)
		{
			dbObject.TypeName = entity.TypeName;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<DrugType>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<DrugType> dbObjects, drug_typesSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.DrugType>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<DrugType> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<DrugType, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.DrugType, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.DrugType ConvertDbObjectToEntity(DrugType dbObject)
		{
			return dbObject == null ? null : new Entities.DrugType(dbObject.Id, dbObject.TypeName);
		}
	}
}
