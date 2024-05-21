using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using EmployeeAttendance = Entities.EmployeeAttendance;

namespace BL
{
	public class employee_attendanceBL
	{
		public async Task<int> AddOrUpdateAsync(EmployeeAttendance entity)
		{
			entity.Id = await new employee_attendanceDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new employee_attendanceDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(employee_attendanceSearchParams searchParams)
		{
			return new employee_attendanceDal().ExistsAsync(searchParams);
		}

		public Task<EmployeeAttendance> GetAsync(int id)
		{
			return new employee_attendanceDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new employee_attendanceDal().DeleteAsync(id);
		}

		public Task<SearchResult<EmployeeAttendance>> GetAsync(employee_attendanceSearchParams searchParams)
		{
			return new employee_attendanceDal().GetAsync(searchParams);
		}
	}
}

