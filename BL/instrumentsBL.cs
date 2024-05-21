using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Instrument = Entities.Instrument;

namespace BL
{
	public class instrumentsBL
	{
		public async Task<int> AddOrUpdateAsync(Instrument entity)
		{
			entity.Id = await new instrumentsDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new instrumentsDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(instrumentsSearchParams searchParams)
		{
			return new instrumentsDal().ExistsAsync(searchParams);
		}

		public Task<Instrument> GetAsync(int id)
		{
			return new instrumentsDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new instrumentsDal().DeleteAsync(id);
		}

		public Task<SearchResult<Instrument>> GetAsync(instrumentsSearchParams searchParams)
		{
			return new instrumentsDal().GetAsync(searchParams);
		}
	}
}

