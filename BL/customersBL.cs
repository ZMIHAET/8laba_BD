using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Customer = Entities.Customer;

namespace BL
{
	public class customersBL
	{
		public async Task<int> AddOrUpdateAsync(Customer entity)
		{
			entity.Id = await new customersDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new customersDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(customersSearchParams searchParams)
		{
			return new customersDal().ExistsAsync(searchParams);
		}

		public Task<Customer> GetAsync(int id)
		{
			return new customersDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new customersDal().DeleteAsync(id);
		}

		public Task<SearchResult<Customer>> GetAsync(customersSearchParams searchParams)
		{
			return new customersDal().GetAsync(searchParams);
		}
	}
}

