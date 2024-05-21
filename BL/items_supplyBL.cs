using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using ItemsSupply = Entities.ItemsSupply;

namespace BL
{
	public class items_supplyBL
	{
		public async Task<int> AddOrUpdateAsync(ItemsSupply entity)
		{
			entity.Id = await new items_supplyDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new items_supplyDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(items_supplySearchParams searchParams)
		{
			return new items_supplyDal().ExistsAsync(searchParams);
		}

		public Task<ItemsSupply> GetAsync(int id)
		{
			return new items_supplyDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new items_supplyDal().DeleteAsync(id);
		}

		public Task<SearchResult<ItemsSupply>> GetAsync(items_supplySearchParams searchParams)
		{
			return new items_supplyDal().GetAsync(searchParams);
		}
	}
}

