using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using ItemsInOrder = Entities.ItemsInOrder;

namespace BL
{
	public class items_in_orderBL
	{
		public async Task<int> AddOrUpdateAsync(ItemsInOrder entity)
		{
			entity.Id = await new items_in_orderDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new items_in_orderDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(items_in_orderSearchParams searchParams)
		{
			return new items_in_orderDal().ExistsAsync(searchParams);
		}

		public Task<ItemsInOrder> GetAsync(int id)
		{
			return new items_in_orderDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new items_in_orderDal().DeleteAsync(id);
		}

		public Task<SearchResult<ItemsInOrder>> GetAsync(items_in_orderSearchParams searchParams)
		{
			return new items_in_orderDal().GetAsync(searchParams);
		}
	}
}

