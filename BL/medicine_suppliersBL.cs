using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using MedicineSupplier = Entities.MedicineSupplier;

namespace BL
{
	public class medicine_suppliersBL
	{
		public async Task<int> AddOrUpdateAsync(MedicineSupplier entity)
		{
			entity.Id = await new medicine_suppliersDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new medicine_suppliersDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(medicine_suppliersSearchParams searchParams)
		{
			return new medicine_suppliersDal().ExistsAsync(searchParams);
		}

		public Task<MedicineSupplier> GetAsync(int id)
		{
			return new medicine_suppliersDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new medicine_suppliersDal().DeleteAsync(id);
		}

		public Task<SearchResult<MedicineSupplier>> GetAsync(medicine_suppliersSearchParams searchParams)
		{
			return new medicine_suppliersDal().GetAsync(searchParams);
		}
	}
}

