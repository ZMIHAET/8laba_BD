using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using MedicineType = Entities.MedicineType;

namespace BL
{
	public class medicine_typesBL
	{
		public async Task<int> AddOrUpdateAsync(MedicineType entity)
		{
			entity.Id = await new medicine_typesDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new medicine_typesDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(medicine_typesSearchParams searchParams)
		{
			return new medicine_typesDal().ExistsAsync(searchParams);
		}

		public Task<MedicineType> GetAsync(int id)
		{
			return new medicine_typesDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new medicine_typesDal().DeleteAsync(id);
		}

		public Task<SearchResult<MedicineType>> GetAsync(medicine_typesSearchParams searchParams)
		{
			return new medicine_typesDal().GetAsync(searchParams);
		}
	}
}

