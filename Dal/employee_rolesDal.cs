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
	public class employee_rolesDal : BaseDal<DefaultDbContext, EmployeeRole, Entities.EmployeeRole, int, employee_rolesSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public employee_rolesDal()
		{
		}

		protected internal employee_rolesDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.EmployeeRole entity, EmployeeRole dbObject, bool exists)
		{
			dbObject.RoleName = entity.RoleName;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<EmployeeRole>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<EmployeeRole> dbObjects, employee_rolesSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.EmployeeRole>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<EmployeeRole> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<EmployeeRole, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.EmployeeRole, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.EmployeeRole ConvertDbObjectToEntity(EmployeeRole dbObject)
		{
			return dbObject == null ? null : new Entities.EmployeeRole(dbObject.Id, dbObject.RoleName);
		}
	}
}
