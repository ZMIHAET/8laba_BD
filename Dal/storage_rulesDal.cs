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
	public class storage_rulesDal : BaseDal<DefaultDbContext, StorageRule, Entities.StorageRule, int, storage_rulesSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public storage_rulesDal()
		{
		}

		protected internal storage_rulesDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.StorageRule entity, StorageRule dbObject, bool exists)
		{
			dbObject.RuleName = entity.RuleName;
			dbObject.Description = entity.Description;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<StorageRule>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<StorageRule> dbObjects, storage_rulesSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.StorageRule>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<StorageRule> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<StorageRule, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.StorageRule, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.StorageRule ConvertDbObjectToEntity(StorageRule dbObject)
		{
			return dbObject == null ? null : new Entities.StorageRule(dbObject.Id, dbObject.RuleName,
				dbObject.Description);
		}
	}
}
