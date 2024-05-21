using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Manufacturer = Entities.Manufacturer;

namespace BL
{
	public class manufacturersBL
	{
		public async Task<int> AddOrUpdateAsync(Manufacturer entity)
		{
			entity.Id = await new manufacturersDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new manufacturersDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(manufacturersSearchParams searchParams)
		{
			return new manufacturersDal().ExistsAsync(searchParams);
		}

		public Task<Manufacturer> GetAsync(int id)
		{
			return new manufacturersDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new manufacturersDal().DeleteAsync(id);
		}

		public Task<SearchResult<Manufacturer>> GetAsync(manufacturersSearchParams searchParams)
		{
			return new manufacturersDal().GetAsync(searchParams);
		}
	}
}

