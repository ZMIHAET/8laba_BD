using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Employee = Entities.Employee;

namespace BL
{
	public class employeesBL
	{
		public async Task<int> AddOrUpdateAsync(Employee entity)
		{
			entity.Id = await new employeesDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new employeesDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(employeesSearchParams searchParams)
		{
			return new employeesDal().ExistsAsync(searchParams);
		}

		public Task<Employee> GetAsync(int id)
		{
			return new employeesDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new employeesDal().DeleteAsync(id);
		}

		public Task<SearchResult<Employee>> GetAsync(employeesSearchParams searchParams)
		{
			return new employeesDal().GetAsync(searchParams);
		}
	}
}

