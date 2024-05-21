using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using MedicineReview = Entities.MedicineReview;

namespace BL
{
	public class medicine_reviewsBL
	{
		public async Task<int> AddOrUpdateAsync(MedicineReview entity)
		{
			entity.Id = await new medicine_reviewsDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new medicine_reviewsDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(medicine_reviewsSearchParams searchParams)
		{
			return new medicine_reviewsDal().ExistsAsync(searchParams);
		}

		public Task<MedicineReview> GetAsync(int id)
		{
			return new medicine_reviewsDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new medicine_reviewsDal().DeleteAsync(id);
		}

		public Task<SearchResult<MedicineReview>> GetAsync(medicine_reviewsSearchParams searchParams)
		{
			return new medicine_reviewsDal().GetAsync(searchParams);
		}
	}
}

