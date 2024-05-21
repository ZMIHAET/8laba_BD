using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Medicine = Entities.Medicine;

namespace BL
{
	public class medicinesBL
	{
		public async Task<int> AddOrUpdateAsync(Medicine entity)
		{
			entity.Id = await new medicinesDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new medicinesDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(medicinesSearchParams searchParams)
		{
			return new medicinesDal().ExistsAsync(searchParams);
		}

		public Task<Medicine> GetAsync(int id)
		{
			return new medicinesDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new medicinesDal().DeleteAsync(id);
		}

		public Task<SearchResult<Medicine>> GetAsync(medicinesSearchParams searchParams)
		{
			return new medicinesDal().GetAsync(searchParams);
		}
	}
}

