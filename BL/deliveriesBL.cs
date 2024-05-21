using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Delivery = Entities.Delivery;

namespace BL
{
	public class deliveriesBL
	{
		public async Task<int> AddOrUpdateAsync(Delivery entity)
		{
			entity.Id = await new deliveriesDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new deliveriesDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(deliveriesSearchParams searchParams)
		{
			return new deliveriesDal().ExistsAsync(searchParams);
		}

		public Task<Delivery> GetAsync(int id)
		{
			return new deliveriesDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new deliveriesDal().DeleteAsync(id);
		}

		public Task<SearchResult<Delivery>> GetAsync(deliveriesSearchParams searchParams)
		{
			return new deliveriesDal().GetAsync(searchParams);
		}
	}
}

