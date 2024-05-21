using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Medication = Entities.Medication;

namespace BL
{
	public class medicationsBL
	{
		public async Task<int> AddOrUpdateAsync(Medication entity)
		{
			entity.Id = await new medicationsDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new medicationsDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(medicationsSearchParams searchParams)
		{
			return new medicationsDal().ExistsAsync(searchParams);
		}

		public Task<Medication> GetAsync(int id)
		{
			return new medicationsDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new medicationsDal().DeleteAsync(id);
		}

		public Task<SearchResult<Medication>> GetAsync(medicationsSearchParams searchParams)
		{
			return new medicationsDal().GetAsync(searchParams);
		}
	}
}

