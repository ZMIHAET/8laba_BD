using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using EmployeeTraining = Entities.EmployeeTraining;

namespace BL
{
	public class employee_trainingsBL
	{
		public async Task<int> AddOrUpdateAsync(EmployeeTraining entity)
		{
			entity.Id = await new employee_trainingsDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new employee_trainingsDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(employee_trainingsSearchParams searchParams)
		{
			return new employee_trainingsDal().ExistsAsync(searchParams);
		}

		public Task<EmployeeTraining> GetAsync(int id)
		{
			return new employee_trainingsDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new employee_trainingsDal().DeleteAsync(id);
		}

		public Task<SearchResult<EmployeeTraining>> GetAsync(employee_trainingsSearchParams searchParams)
		{
			return new employee_trainingsDal().GetAsync(searchParams);
		}
	}
}

