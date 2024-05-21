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
	public class medicine_reviewsDal : BaseDal<DefaultDbContext, MedicineReview, Entities.MedicineReview, int, medicine_reviewsSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public medicine_reviewsDal()
		{
		}

		protected internal medicine_reviewsDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.MedicineReview entity, MedicineReview dbObject, bool exists)
		{
			dbObject.MedicineId = entity.MedicineId;
			dbObject.CustomerId = entity.CustomerId;
			dbObject.Rating = entity.Rating;
			dbObject.ReviewText = entity.ReviewText;
			dbObject.ReviewDate = entity.ReviewDate;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<MedicineReview>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<MedicineReview> dbObjects, medicine_reviewsSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.MedicineReview>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<MedicineReview> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<MedicineReview, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.MedicineReview, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.MedicineReview ConvertDbObjectToEntity(MedicineReview dbObject)
		{
			return dbObject == null ? null : new Entities.MedicineReview(dbObject.Id, dbObject.MedicineId,
				dbObject.CustomerId, dbObject.Rating, dbObject.ReviewText, dbObject.ReviewDate);
		}
	}
}
