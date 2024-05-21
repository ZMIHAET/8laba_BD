using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using EmployeeRole = Entities.EmployeeRole;

namespace BL
{
	public class employee_rolesBL
	{
		public async Task<int> AddOrUpdateAsync(EmployeeRole entity)
		{
			entity.Id = await new employee_rolesDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new employee_rolesDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(employee_rolesSearchParams searchParams)
		{
			return new employee_rolesDal().ExistsAsync(searchParams);
		}

		public Task<EmployeeRole> GetAsync(int id)
		{
			return new employee_rolesDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new employee_rolesDal().DeleteAsync(id);
		}

		public Task<SearchResult<EmployeeRole>> GetAsync(employee_rolesSearchParams searchParams)
		{
			return new employee_rolesDal().GetAsync(searchParams);
		}
	}
}

