using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Order = Entities.Order;

namespace BL
{
	public class ordersBL
	{
		public async Task<int> AddOrUpdateAsync(Order entity)
		{
			entity.Id = await new ordersDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new ordersDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(ordersSearchParams searchParams)
		{
			return new ordersDal().ExistsAsync(searchParams);
		}

		public Task<Order> GetAsync(int id)
		{
			return new ordersDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new ordersDal().DeleteAsync(id);
		}

		public Task<SearchResult<Order>> GetAsync(ordersSearchParams searchParams)
		{
			return new ordersDal().GetAsync(searchParams);
		}
	}
}

