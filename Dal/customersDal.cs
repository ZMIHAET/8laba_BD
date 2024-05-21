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
	public class customersDal : BaseDal<DefaultDbContext, Customer, Entities.Customer, int, customersSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public customersDal()
		{
		}

		protected internal customersDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Customer entity, Customer dbObject, bool exists)
		{
			dbObject.FullName = entity.FullName;
			dbObject.DateOfBirth = entity.DateOfBirth;
			dbObject.Phone = entity.Phone;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Customer>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Customer> dbObjects, customersSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Customer>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Customer> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Customer, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Customer, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Customer ConvertDbObjectToEntity(Customer dbObject)
		{
			return dbObject == null ? null : new Entities.Customer(dbObject.Id, dbObject.FullName,
				dbObject.DateOfBirth, dbObject.Phone);
		}
	}
}
