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
	public class employeesDal : BaseDal<DefaultDbContext, Employee, Entities.Employee, int, employeesSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public employeesDal()
		{
		}

		protected internal employeesDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Employee entity, Employee dbObject, bool exists)
		{
			dbObject.FullName = entity.FullName;
			dbObject.DateOfBirth = entity.DateOfBirth;
			dbObject.Phone = entity.Phone;
			dbObject.RoleId = entity.RoleId;
			dbObject.HireDate = entity.HireDate;
			dbObject.Salary = entity.Salary;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Employee>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Employee> dbObjects, employeesSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Employee>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Employee> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Employee, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Employee, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Employee ConvertDbObjectToEntity(Employee dbObject)
		{
			return dbObject == null ? null : new Entities.Employee(dbObject.Id, dbObject.FullName,
				dbObject.DateOfBirth, dbObject.Phone, dbObject.RoleId, dbObject.HireDate, dbObject.Salary);
		}
	}
}
