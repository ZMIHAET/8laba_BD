using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using MedicineDiscount = Entities.MedicineDiscount;

namespace BL
{
	public class medicine_discountsBL
	{
		public async Task<int> AddOrUpdateAsync(MedicineDiscount entity)
		{
			entity.Id = await new medicine_discountsDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new medicine_discountsDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(medicine_discountsSearchParams searchParams)
		{
			return new medicine_discountsDal().ExistsAsync(searchParams);
		}

		public Task<MedicineDiscount> GetAsync(int id)
		{
			return new medicine_discountsDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new medicine_discountsDal().DeleteAsync(id);
		}

		public Task<SearchResult<MedicineDiscount>> GetAsync(medicine_discountsSearchParams searchParams)
		{
			return new medicine_discountsDal().GetAsync(searchParams);
		}
	}
}

