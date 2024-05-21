using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Equipment = Entities.Equipment;

namespace BL
{
	public class equipmentBL
	{
		public async Task<int> AddOrUpdateAsync(Equipment entity)
		{
			entity.Id = await new equipmentDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new equipmentDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(equipmentSearchParams searchParams)
		{
			return new equipmentDal().ExistsAsync(searchParams);
		}

		public Task<Equipment> GetAsync(int id)
		{
			return new equipmentDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new equipmentDal().DeleteAsync(id);
		}

		public Task<SearchResult<Equipment>> GetAsync(equipmentSearchParams searchParams)
		{
			return new equipmentDal().GetAsync(searchParams);
		}
	}
}

