﻿using System;
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
	public class suppliersDal : BaseDal<DefaultDbContext, Supplier, Entities.Supplier, int, suppliersSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public suppliersDal()
		{
		}

		protected internal suppliersDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Supplier entity, Supplier dbObject, bool exists)
		{
			dbObject.SupplierName = entity.SupplierName;
			dbObject.Address = entity.Address;
			dbObject.Phone = entity.Phone;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Supplier>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Supplier> dbObjects, suppliersSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Supplier>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Supplier> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Supplier, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Supplier, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Supplier ConvertDbObjectToEntity(Supplier dbObject)
		{
			return dbObject == null ? null : new Entities.Supplier(dbObject.Id, dbObject.SupplierName,
				dbObject.Address, dbObject.Phone);
		}
	}
}
