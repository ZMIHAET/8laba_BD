using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Supplier = Entities.Supplier;

namespace BL
{
	public class suppliersBL
	{
		public async Task<int> AddOrUpdateAsync(Supplier entity)
		{
			entity.Id = await new suppliersDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new suppliersDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(suppliersSearchParams searchParams)
		{
			return new suppliersDal().ExistsAsync(searchParams);
		}

		public Task<Supplier> GetAsync(int id)
		{
			return new suppliersDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new suppliersDal().DeleteAsync(id);
		}

		public Task<SearchResult<Supplier>> GetAsync(suppliersSearchParams searchParams)
		{
			return new suppliersDal().GetAsync(searchParams);
		}
	}
}

