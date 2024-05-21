using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Courier = Entities.Courier;

namespace BL
{
	public class couriersBL
	{
		public async Task<int> AddOrUpdateAsync(Courier entity)
		{
			entity.Id = await new couriersDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new couriersDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(couriersSearchParams searchParams)
		{
			return new couriersDal().ExistsAsync(searchParams);
		}

		public Task<Courier> GetAsync(int id)
		{
			return new couriersDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new couriersDal().DeleteAsync(id);
		}

		public Task<SearchResult<Courier>> GetAsync(couriersSearchParams searchParams)
		{
			return new couriersDal().GetAsync(searchParams);
		}
	}
}

