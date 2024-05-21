using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using StorageRule = Entities.StorageRule;

namespace BL
{
	public class storage_rulesBL
	{
		public async Task<int> AddOrUpdateAsync(StorageRule entity)
		{
			entity.Id = await new storage_rulesDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new storage_rulesDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(storage_rulesSearchParams searchParams)
		{
			return new storage_rulesDal().ExistsAsync(searchParams);
		}

		public Task<StorageRule> GetAsync(int id)
		{
			return new storage_rulesDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new storage_rulesDal().DeleteAsync(id);
		}

		public Task<SearchResult<StorageRule>> GetAsync(storage_rulesSearchParams searchParams)
		{
			return new storage_rulesDal().GetAsync(searchParams);
		}
	}
}

