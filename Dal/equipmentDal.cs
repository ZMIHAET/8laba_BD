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
	public class equipmentDal : BaseDal<DefaultDbContext, Equipment, Entities.Equipment, int, equipmentSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public equipmentDal()
		{
		}

		protected internal equipmentDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Equipment entity, Equipment dbObject, bool exists)
		{
			dbObject.EquipmentName = entity.EquipmentName;
			dbObject.ExpirationDate = entity.ExpirationDate;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Equipment>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Equipment> dbObjects, equipmentSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Equipment>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Equipment> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Equipment, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Equipment, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Equipment ConvertDbObjectToEntity(Equipment dbObject)
		{
			return dbObject == null ? null : new Entities.Equipment(dbObject.Id, dbObject.EquipmentName,
				dbObject.ExpirationDate);
		}
	}
}
