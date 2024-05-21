using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using DrugType = Entities.DrugType;

namespace BL
{
	public class drug_typesBL
	{
		public async Task<int> AddOrUpdateAsync(DrugType entity)
		{
			entity.Id = await new drug_typesDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new drug_typesDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(drug_typesSearchParams searchParams)
		{
			return new drug_typesDal().ExistsAsync(searchParams);
		}

		public Task<DrugType> GetAsync(int id)
		{
			return new drug_typesDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new drug_typesDal().DeleteAsync(id);
		}

		public Task<SearchResult<DrugType>> GetAsync(drug_typesSearchParams searchParams)
		{
			return new drug_typesDal().GetAsync(searchParams);
		}
	}
}

