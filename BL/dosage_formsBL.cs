using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using DosageForm = Entities.DosageForm;

namespace BL
{
	public class dosage_formsBL
	{
		public async Task<int> AddOrUpdateAsync(DosageForm entity)
		{
			entity.Id = await new dosage_formsDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new dosage_formsDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(dosage_formsSearchParams searchParams)
		{
			return new dosage_formsDal().ExistsAsync(searchParams);
		}

		public Task<DosageForm> GetAsync(int id)
		{
			return new dosage_formsDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new dosage_formsDal().DeleteAsync(id);
		}

		public Task<SearchResult<DosageForm>> GetAsync(dosage_formsSearchParams searchParams)
		{
			return new dosage_formsDal().GetAsync(searchParams);
		}
	}
}

